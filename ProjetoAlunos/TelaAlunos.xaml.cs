using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjetoAlunos {
    public partial class TelaAlunos : Window {
        Oracle oracle = new Oracle();

        List<string> tables = new List<string>();
        List<string> rows = new List<string>();

        string alunos = "Alunos";
        string cidades = "Cidades";
        string cursos = "Cursos";
        string disciplinas = "Disciplinas";
        string regAcad = "Registro Acadêmico";
        string regAcadDisc = "Reg. Acad. por Disciplina";
        //string notas = "Notas";

        public TelaAlunos() {
            InitializeComponent();
            oracle.Connect();

            MyDataGrid.RowHeaderWidth = 0;
            MyDataGrid.CanUserDeleteRows = false;
            MyDataGrid.CanUserSortColumns = false;

            tables.Add("Alunos");
            tables.Add("Cidades");
            tables.Add("Cursos");
            tables.Add("Disciplinas");
            tables.Add("Registro Acadêmico");
            tables.Add("Reg. Acad. por Disciplina");
            tables.Add("Notas");
            CB_Table.ItemsSource = tables;
        }

        void BindAndUpdate(string type) {
            string query = String.Empty;
            string text = CB_Table.SelectedItem.ToString();

            if (type.Equals(alunos)) {
                query = "SELECT " +
                            "a.codigo, " +
                            "a.nome, " +
                            "a.sobrenome, " +
                            "a.codcidade||' - '||b.nome cidade, " +
                            "SUBSTR(a.cpf, 1, 3)||'.'||SUBSTR(a.cpf, 3, 3)||'.'||SUBSTR(a.cpf, 7, 3)||'-'||SUBSTR(a.cpf, 10, 12) cpf, " +
                            "TO_CHAR(a.datanascimento, 'DD/MM/YYYY') nascimento " +
                        "FROM aluno a " +
                        "INNER JOIN cidade b ON a.codcidade = b.codigo";
            } else if (type.Equals(cidades)) {
                query = "SELECT " +
                            "codigo, " +
                            "nome, " +
                            "uf estado " +
                        "FROM cidade";
            } else if (type.Equals(cursos)) {
                query = "SELECT cod codigo, " +
                            "nome, " +
                            "TO_CHAR(datainicio, 'DD/MM/YYYY') inicio, " +
                            "cargahoraria||' horas' carga " +
                        "FROM curso";
            } else if (type.Equals(disciplinas)) {
                query = "SELECT " +
                            "cod codigo, " +
                            "nome, " +
                            "valor " +
                        "FROM disciplina";
            } else if (type.Equals(regAcad)) {
                query = "SELECT " +
                            "a.cod codigo, " +
                            "a.numero_matricula matricula, " +
                            "a.semestre, a.cod_aluno||' - '||b.nome||' '||b.sobrenome nome, " +
                            "a.cod_curso||' - '||c.nome curso " +
                        "FROM registro_academico a " +
                        "INNER JOIN aluno b ON a.cod_aluno = b.codigo " +
                        "INNER JOIN curso c ON a.cod_curso = c.cod";
            } else if (type.Equals(regAcadDisc)) {
                query = "SELECT " +
                            "a.cod codigo, " +
                            "a.cod_reg_academico||' - '||b.numero_matricula matricula, " +
                            "a.cod_disciplina||' - '||c.nome disciplina " +
                        "FROM registro_academico_disciplina a " +
                        "INNER JOIN registro_academico b ON b.cod = a.cod_reg_academico " +
                        "INNER JOIN disciplina c ON c.cod = a.cod_disciplina";
            } else {
                query = "SELECT " +
                            "a.cod codigo, " +
                            "a.codregacad||' - '||b.numero_matricula matricula, " +
                            "a.coddisciplina||' - '||c.nome disciplina, " +
                            "a.nota1, " +
                            "a.nota2, " +
                            "a.nota3, " +
                            "a.media " +
                        "FROM nota a " +
                        "INNER JOIN registro_academico b ON b.cod = a.codregacad " +
                        "INNER JOIN disciplina c ON C.cod = a.coddisciplina";
            }

            oracle.BindToDataGrid(MyDataGrid, query);
        }

        private void CB_Table_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            string text = CB_Table.SelectedItem.ToString();

            BindAndUpdate(text);
        }

        private void B_Inserir(object sender, RoutedEventArgs e) {

        }

        private void B_Deletar(object sender, RoutedEventArgs e) {
            string type = CB_Table.Text;
            string id = rows[0];

            if (type.Equals(alunos)) {
                bool deleted = oracle.InsertOrUpdate($"DELETE FROM aluno WHERE codigo = {id}");

                if (deleted)
                    MessageBox.Show($"Deletado aluno {id}");
                else
                    MessageBox.Show("Erro, este aluno existe em outro cadastro!");

                BindAndUpdate(alunos);
            } else if (type.Equals(cidades)) {
                bool deleted = oracle.InsertOrUpdate($"DELETE FROM cidade WHERE codigo = {id}");

                if (deleted)
                    MessageBox.Show($"Deletada cidade {id}");
                else
                    MessageBox.Show("Erro, esta cidade existe em outro cadastro!");

                BindAndUpdate(cidades);
            } else if (type.Equals(cursos)) {
                bool deleted = oracle.InsertOrUpdate($"DELETE FROM curso WHERE cod = {id}");

                if (deleted)
                    MessageBox.Show($"Deletado curso {id}");
                else
                    MessageBox.Show("Erro, este curso existe em outro cadastro!");

                BindAndUpdate(cursos);
            } else if (type.Equals(disciplinas)) {
                bool deleted = oracle.InsertOrUpdate($"DELETE FROM disciplina WHERE cod = {id}");

                if (deleted)
                    MessageBox.Show($"Deletada disciplina {id}");
                else
                    MessageBox.Show("Erro, esta disciplina existe em outro cadastro!");

                BindAndUpdate(disciplinas);
            } else if (type.Equals(regAcad)) {
                bool deleted = oracle.InsertOrUpdate($"DELETE FROM registro_academico WHERE cod = {id}");

                if (deleted)
                    MessageBox.Show($"Deletado registro academico {id}");
                else
                    MessageBox.Show("Erro, este registro academico existe em outro cadastro!");

                BindAndUpdate(regAcad);
            } else if (type.Equals(regAcadDisc)) {
                bool deleted = oracle.InsertOrUpdate($"DELETE FROM registro_academico_disciplina WHERE cod = {id}");

                if (deleted)
                    MessageBox.Show($"Deletada registro academico disciplina {id}");
                else
                    MessageBox.Show("Erro!");

                BindAndUpdate(regAcadDisc);
            } else {
                bool deleted = oracle.InsertOrUpdate($"DELETE FROM nota WHERE cod = {id}");

                if (deleted)
                    MessageBox.Show($"Deletada nota {id}");
                else
                    MessageBox.Show("Erro");

                BindAndUpdate("ELSE");
            }
        }

        private void B_Modificar(object sender, RoutedEventArgs e) {
            
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            string type = CB_Table.Text;

            if (type.Equals(alunos)) {
                DataGrid gd = (DataGrid)sender;
                DataRowView rowSelected = gd.SelectedItem as DataRowView;

                rows.Clear();
                if(rowSelected != null) {
                    rows.Add(rowSelected["codigo"].ToString());
                    rows.Add(rowSelected["nome"].ToString());
                    rows.Add(rowSelected["sobrenome"].ToString());
                    rows.Add(rowSelected["cidade"].ToString());
                    rows.Add(rowSelected["nascimento"].ToString());
                }
                    
            } else if (type.Equals(cidades)) {
                DataGrid gd = (DataGrid)sender;
                DataRowView rowSelected = gd.SelectedItem as DataRowView;

                rows.Clear();
                if(rowSelected != null) {
                    rows.Add(rowSelected["codigo"].ToString());
                    rows.Add(rowSelected["nome"].ToString());
                    rows.Add(rowSelected["estado"].ToString());
                } 
            } else if (type.Equals(cursos)) {
                DataGrid gd = (DataGrid)sender;
                DataRowView rowSelected = gd.SelectedItem as DataRowView;

                rows.Clear();
                if (rowSelected != null) {
                    rows.Add(rowSelected["codigo"].ToString());
                    rows.Add(rowSelected["nome"].ToString());
                    rows.Add(rowSelected["inicio"].ToString());
                    rows.Add(rowSelected["carga"].ToString());
                }
            } else if (type.Equals(disciplinas)) {
                DataGrid gd = (DataGrid)sender;
                DataRowView rowSelected = gd.SelectedItem as DataRowView;

                rows.Clear();
                if (rowSelected != null) {
                    rows.Add(rowSelected["codigo"].ToString());
                    rows.Add(rowSelected["nome"].ToString());
                    rows.Add(rowSelected["valor"].ToString());
                }
            } else if (type.Equals(regAcad)) {
                DataGrid gd = (DataGrid)sender;
                DataRowView rowSelected = gd.SelectedItem as DataRowView;

                rows.Clear();

                if (rowSelected != null) {
                    rows.Add(rowSelected["codigo"].ToString());
                    rows.Add(rowSelected["matricula"].ToString());
                    rows.Add(rowSelected["nome"].ToString());
                    rows.Add(rowSelected["curso"].ToString());
                }

            } else if (type.Equals(regAcadDisc)) {
                DataGrid gd = (DataGrid)sender;
                DataRowView rowSelected = gd.SelectedItem as DataRowView;

                rows.Clear();

                if (rowSelected != null) {
                    rows.Add(rowSelected["codigo"].ToString());
                    rows.Add(rowSelected["matricula"].ToString());
                    rows.Add(rowSelected["disciplina"].ToString());
                }
            } else {
                DataGrid gd = (DataGrid)sender;
                DataRowView rowSelected = gd.SelectedItem as DataRowView;

                rows.Clear();
                if (rowSelected != null) {
                    rows.Add(rowSelected["codigo"].ToString());
                    rows.Add(rowSelected["matricula"].ToString());
                    rows.Add(rowSelected["disciplina"].ToString());
                    rows.Add(rowSelected["nota1"].ToString());
                    rows.Add(rowSelected["nota2"].ToString());
                    rows.Add(rowSelected["nota3"].ToString());
                    rows.Add(rowSelected["media"].ToString());
                }
            }
        }
    }
}