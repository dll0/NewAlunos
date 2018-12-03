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
using System.Windows.Shapes;

namespace ProjetoAlunos {
    public partial class Ferramentas : Window {
        Oracle oracle = new Oracle();
        EventManipulation evt = new EventManipulation();

        public Ferramentas() {
            oracle.Connect();
            InitializeComponent();
        }

        private void B_ApagaRecria(object sender, RoutedEventArgs e) {
            bool wasExecuted = oracle.Script("Arquivos/script.sql");

            evt.SuccessBox("Base recriada.", "Recriação falhou", wasExecuted);
        }

        private void B_DadosPadrao(object sender, RoutedEventArgs e) {
            bool wasExecuted = oracle.Script("Arquivos/default.sql");

            evt.SuccessBox("Dados padrões inseridos", "Dados não inseridos", wasExecuted);
        }

        private void B_VerificaLogin(object sender, RoutedEventArgs e) {
            object queryReturn = oracle.Query("SELECT nome, senha FROM usuario", "nome", "senha");
            bool querySuccess = false;

            string user = "", password = "";

            if (!queryReturn.ToString().Equals("-1")) {
                IList<string> query = (IList<string>)queryReturn;
                querySuccess = true;

                int i = 0;
                foreach (string s in query) {
                    if (i == 0)
                        user = s;
                    else
                        password = s;

                    i++;
                }
            } else {
                querySuccess = false;
            }
                
            evt.SuccessBox($"Nome de usuário: {user}{Environment.NewLine}Senha: {password}", "Usuário não registrado", querySuccess);
        }

        private void B_MudaSenha(object sender, RoutedEventArgs e) {
            string password = "123456";

            while (password.Length > 5) {
                MessageBox.Show("ATENÇÃO! Não pode ter mais que 5 digitos numéricos!");
                password = Microsoft.VisualBasic.Interaction.InputBox("Digite a nova senha:", "Redefinir senha", "12345");
            }
            
            bool wasUpdated = oracle.InsertOrUpdate($"UPDATE usuario SET senha = {password}");

            evt.SuccessBox("Senha alterada", "Senha não alterada", wasUpdated);
        }
    }
}
