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
            bool isConnected = oracle.Connect();

            Usuario usuario = new Usuario();
            usuario.ShowDialog();

            /*if (isConnected) {
                MessageBox.Show($"Conectado ao Oracle {oracle.getVersao()}");

                string query = oracle.Query("SELECT nome FROM usuario", "S", false);
                bool isFirstTime = query.Equals("-1");
                if (isFirstTime) {
                    bool wasExecuted = oracle.Script("C:\\Users\\Matheus\\Documents\\GitHub\\" +
                                        "ProjetoAlunos\\ProjetoAlunos\\Arquivos\\DropANDCria.sql");

                    if (wasExecuted) {
                        MessageBox.Show("Script executado, todas as tabelas foram criadas");
                        */

            /* } else {
                 MessageBox.Show("Script não executado");
             }
         } else {
             MessageBox.Show("Usuário já existe");
         }
     }  else {
         MessageBox.Show("Não conectado");
     }*/

            //oracle.Close();
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
