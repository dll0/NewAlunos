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
        StringManipulation manipulation = new StringManipulation();

        private string userNameTB = "Nome de usuário obrigatório!";
        private string maxChar = "Máximo de 8 caracteres!";
        private string onlyAlpha = "Somente caracteres do alfabeto";
        private bool userGotFocused = false;
        private bool isCommonText;

        public Usuario() {
            InitializeComponent();
            tbUser.Text = userNameTB;
            oracle.Connect();
        }

        private void tbUser_GotFocus(object sender, RoutedEventArgs e) {
            userGotFocused = true;
            string tbString = tbUser.Text.ToString();
            string tbStringNoSpace = tbString.Replace(" ", String.Empty);

            if (tbStringNoSpace.Equals(String.Empty)) {
                tbUser.Text = userNameTB;
            } else if (tbString.Equals(userNameTB)) {
                tbUser.Text = String.Empty;
            }
        }

        private void tbUser_LostFocus(object sender, RoutedEventArgs e) {
            string tbString = tbUser.Text.ToString();
            string tbStringNoSpace = tbString.Replace(" ", String.Empty);
            bool haveOnlyAlpha = Regex.IsMatch(tbString, @"^[a-zA-Z]+$");

            if (tbStringNoSpace.Equals(String.Empty)) {
                tbUser.Text = userNameTB;
            } else if (tbString.Length > 8 
                    && !tbString.Equals(userNameTB) 
                    && !tbString.Equals(maxChar)
                    && !tbString.Equals(onlyAlpha)){
                MessageBox.Show($"{maxChar}{Environment.NewLine}O nome de usuário '{tbString}' não atende aos requisitos");
                tbUser.Text = maxChar;
                Task.Delay(100).ContinueWith(_ => { Application.Current.Dispatcher.Invoke(new Action(() => {
                        tbUser.Focus();
                        tbUser.SelectAll();
                    }));
                });
            } else if (!haveOnlyAlpha
                    && !tbString.Equals(onlyAlpha)) {
                tbUser.Text = onlyAlpha;
                int position = 0;
                List<string> changes = new List<string>();

                foreach (char letter in tbString) {
                    position++;
                    if (!Regex.IsMatch(Convert.ToString(letter), @"^[a-zA-Z]+$")) {
                        changes.Add($"{Convert.ToString(position)}: {Convert.ToString(letter)}; ");
                    }
                }

                string changesToDo = string.Join(" ", changes);

                MessageBox.Show($"O nome de usuário deve conter apenas letras [A-Z]{Environment.NewLine}" +
                                $"O nome de usuário '{tbString}' não atende aos requisitos{Environment.NewLine}" +
                                $"{Environment.NewLine}" +
                                $"Caracteres invalidos em suas posições:" +
                                $"{Environment.NewLine}{changesToDo}");
                Task.Delay(100).ContinueWith(_ => {
                    Application.Current.Dispatcher.Invoke(new Action(() => {
                        tbUser.Focus();
                        tbUser.SelectAll();
                    }));
                });
            }
        }


        private void tbPass_LostFocus(object sender, RoutedEventArgs e) {
            string tbString = tbPass.Password.ToString();
            string tbStringNoSpace = tbString.Replace(" ", String.Empty);
            bool haveOnlyNumeric = Regex.IsMatch(tbString, @"^[0-9]+$");
            bool isBlank = tbStringNoSpace.Equals(String.Empty);

            if (tbString.Length > 5) {
                MessageBox.Show($"A senha '{tbString}' não atende aos requisitos" +
                                $"{Environment.NewLine}Deve possuir até 5 números ou ser nula");
                Task.Delay(100).ContinueWith(_ => {
                    Application.Current.Dispatcher.Invoke(new Action(() => {
                        tbPass.Focus();
                        tbPass.SelectAll();
                    }));
                });
            } else if (!haveOnlyNumeric && !isBlank) {
                List<char> changes = new List<char>();

                foreach (char letter in tbString) {
                    if (!Regex.IsMatch(letter.ToString(), @"^[0-9]+$")) {
                        changes.Add(letter);
                    }
                }

                string changesToDo = string.Join("; ", changes);

                MessageBox.Show($"A senha deve conter apenas números [0-9]" +
                                $"{Environment.NewLine}Os seguintes caracteres inválidos foram encontrados:" +
                                $"{Environment.NewLine}{changesToDo};");
                Task.Delay(100).ContinueWith(_ => {
                    Application.Current.Dispatcher.Invoke(new Action(() => {
                        tbPass.Focus();
                        tbPass.SelectAll();
                    }));
                });
            }
        }

        private void bRegister_Click(object sender, RoutedEventArgs e) {
            string tb = tbUser.Text;

            isCommonText = tb.Equals(userNameTB)
                    || tb.Equals(maxChar)
                    || tb.Equals(onlyAlpha);

            string user = manipulation.Capitalize(tb);
            string password = tbPass.Password.ToString();
            bool wasInserted = false;

            string userRegistered = oracle.Query("SELECT nome FROM usuario", "S", false);
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