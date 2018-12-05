using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;

/*
    Não consegui concluir o trabalho, por ser muito extenso
    Se clicar na imagem, tem a opção de inserir dados padrão
    Com eles da pra testar a funcionalidade de excluir na 
    tabela de registro_academico_disciplina.
    Tela de login apenas registra, não valida, fechar ela
    para abrir a tela de pesquisa
*/

namespace ProjetoAlunos {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void B_Inicializa(object sender, RoutedEventArgs e) {
            Oracle oracle = new Oracle();
            oracle.Connect();

            Usuario usuario = new Usuario();
            usuario.ShowDialog();

            TelaAlunos telaAlunos = new TelaAlunos();
            telaAlunos.ShowDialog();
        }

        private void B_Secreto(object sender, MouseButtonEventArgs e) {
            Ferramentas ferramentas = new Ferramentas();
            this.Hide();
            Task.Delay(45);
            ferramentas.ShowDialog();
            this.Show();
        }
    }
}
