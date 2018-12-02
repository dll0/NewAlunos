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

namespace ProjetoAlunos {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void B_Inicializa(object sender, RoutedEventArgs e) {
            Oracle oracle = new Oracle();
            oracle.Connect();

            Usuario usuario = new Usuario();
            //usuario.ShowDialog();

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
