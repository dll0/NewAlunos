using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class Usuario : Window {
        Oracle oracle = new Oracle();
        StringManipulation str = new StringManipulation();
        EventManipulation evt = new EventManipulation();

        private string userNameTB = "Nome de usuário obrigatório!";
        private string maxChar = "Máximo de 8 caracteres!";
        private string onlyAlpha = "Somente caracteres do alfabeto!";
        private bool userGotFocused = false;
        private bool isCommonText;

        public Usuario() {
            InitializeComponent();
            tbUser.Text = userNameTB;
            oracle.Connect();
        }

        private void tbUser_GotFocus(object sender, RoutedEventArgs e) {
            userGotFocused = true;
            string[] commons = { userNameTB };
            string[] messages = { "O nome de usuário", "não atende aos requisitos" };

            evt.Validate(common: commons, gotOrLost: "G", box: tbUser, message: messages);
        }

        private void tbUser_LostFocus(object sender, RoutedEventArgs e) {
            string[] commons = { userNameTB, maxChar, onlyAlpha, "O nome de usuário", "não atende aos requisitos" };
            string[] messages = { "O nome de usuário", "não atende aos requisitos" };

            evt.Validate(common: commons, gotOrLost: "L", box: tbUser,
                mask: new Regex(@"^[a-zA-Z]+$"), showErrors: true, message: messages);
        }

        private void tbPass_LostFocus(object sender, RoutedEventArgs e) {
            string[] messages = { "A senha", "não atende aos requisitos", "Deve possuir até 5 números ou ser nula" };

            evt.Validate(gotOrLost: "L", passBox: tbPass, mask: new Regex(@"^[0-9]+$"), message: messages,
                showErrors: true);
        }

        private void bRegister_Click(object sender, RoutedEventArgs e) {
            string tb = tbUser.Text;

            isCommonText = tb.Equals(userNameTB)
                    || tb.Equals(maxChar)
                    || tb.Equals(onlyAlpha);

            string user = str.Capitalize(tb);
            string password = tbPass.Password.ToString();
            bool wasInserted = false;

            List<String> userRegistered = oracle.Query("SELECT nome FROM usuario");
            bool isUserRegistered = !userRegistered.Equals("-1");

            if (!isUserRegistered
                    && userGotFocused
                    && !isCommonText) {
                wasInserted = oracle.Insert($"INSERT INTO usuario (nome, senha) VALUES ('{user}', '{password}')");
            }

            if (wasInserted) {
                MessageBox.Show($"Usuário '{user}' criado com sucesso");
            } else if (isUserRegistered) {
                MessageBox.Show($"Já existe um usuário cadastro na base de dados. Seu nome é '{userRegistered}'");
            } else if (!wasInserted
                    && !isCommonText
                    && !userGotFocused) {
                MessageBox.Show($"Usuário '{user}' não foi criado, tente novamente");
            } else {
                MessageBox.Show(userNameTB);
            }
        }
    }
}