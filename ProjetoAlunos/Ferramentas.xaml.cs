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
            List<string> queryReturn = oracle.Query("SELECT nome, senha FROM usuario");
            bool querySuccess;

            string user = "", password = "";

            int i = 0;
            foreach (string s in queryReturn) {
                if (i == 0)
                    user = s;
                else
                    password = s;

                i++;
            }

            if (password.Replace(" ", String.Empty).Equals(String.Empty)) {
                password = "EM BRANCO";
            }

            if (!queryReturn.Equals("-1"))
                querySuccess = true;
            else
                querySuccess = false;

            evt.SuccessBox($"Nome de usuário: {user}{Environment.NewLine}Senha: {password}", "Usuário não registrado", querySuccess);
        }
    }
}
