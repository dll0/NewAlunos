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

        List<String> tables = new List<string>();

        public TelaAlunos() {
            InitializeComponent();
            oracle.Connect();

            MyDataGrid.RowHeaderWidth = 0;
            MyDataGrid.CanUserAddRows = false;
            MyDataGrid.CanUserDeleteRows = false;
            MyDataGrid.CanUserReorderColumns = false;
            MyDataGrid.CanUserResizeColumns = false;
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

        void Bind(string type) {
            string query = String.Empty;
            string text = CB_Table.SelectedItem.ToString();

            if (type.Equals("Alunos")) {
                query = "SELECT " +
                            "a.codigo, " +
                            "a.nome, " +
                            "a.sobrenome, " +
                            "a.codcidade||' - '||b.nome cidade, " +
                            "SUBSTR(a.cpf, 1, 3)||'.'||SUBSTR(a.cpf, 3, 3)||'.'||SUBSTR(a.cpf, 7, 3)||'-'||SUBSTR(a.cpf, 10, 12) cpf, " +
                            "TO_CHAR(a.datanascimento, 'DD/MM/YYYY') nascimento " +
                        "FROM aluno a " +
                        "INNER JOIN cidade b ON a.codcidade = b.codigo";
            } else if (type.Equals("Cidades")) {
                query = "SELECT " +
                            "codigo, " +
                            "nome, " +
                            "uf estado " +
                        "FROM cidade";
            } else if (type.Equals("Cursos")) {
                query = "SELECT cod codigo, " +
                            "nome, " +
                            "TO_CHAR(datainicio, 'DD/MM/YYYY') inicio, " +
                            "cargahoraria||' horas' carga " +
                        "FROM curso";
            } else if (type.Equals("Disciplinas")) {
                query = "SELECT " +
                            "cod codigo, " +
                            "nome, " +
                            "valor " +
                        "FROM disciplina";
            } else if (type.Equals("Registro Acadêmico")) {
                query = "SELECT " +
                            "a.cod codigo, " +
                            "a.numero_matricula matricula, " +
                            "a.semestre, a.cod_aluno||' - '||b.nome||' '||b.sobrenome nome, " +
                            "a.cod_curso||' - '||c.nome curso " +
                        "FROM registro_academico a " +
                        "INNER JOIN aluno b ON a.cod_aluno = b.codigo " +
                        "INNER JOIN curso c ON a.cod_curso = c.cod";
            } else if (type.Equals("Reg. Acad. por Disciplina")) {
                query = "SELECT " +
                            "a.cod codigo, " +
                            "a.cod_reg_academico||' - '||b.numero_matricula matricula, " +
                            "a.cod_disciplina||' - '||c.nome disciplina " +
                        "FROM registro_academico_disciplina a " +
                        "INNER JOIN registro_academico b ON b.cod = a.cod_reg_academico " +
                        "INNER JOIN disciplina c ON c.cod = a.cod_disciplina";
            } else {
                query = "SELECT " +
                            "a.cod, " +
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

            Bind(text);
        }
    }
}