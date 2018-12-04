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
using System.Text.RegularExpressions;

namespace ProjetoAlunos {
    public partial class CadastroAluno : Window {
        Oracle oracle = new Oracle();
        EventManipulation evt = new EventManipulation();
        StringManipulation str = new StringManipulation();
        private string mode;

        string namePattern = "Insira o nome do aluno";
        string nameLength = "Máximo de 75 caracteres ultrapassado";
        string nameOnlyAlpha = "O nome deve conter apenas caracteres do alfabeto";

        string lastNamePattern = "Insira o sobrenome do aluno";
        string lastNameLength = "Máximo de 125 caracteres ultrapassado";
        string lastNameOnlyAlpha = "O sobrenome deve conter apenas caracteres do alfabeto";

        string cpfPattern = "Insira o CPF do aluno";
        string cpfLength = "Máximo de 11 caracteres ultrapassado";
        string cpfMask = "O CPF deve conter 11 caracteres numéricos";

        public CadastroAluno(string mode) {
            InitializeComponent();
            oracle.Connect();

            this.mode = mode;

            object select = oracle.Query("SELECT nome FROM cidade", "nome");
            if (select.ToString().Equals("-1")) {
                MessageBox.Show("Não existe nenhuma cidade cadastrada no sistema, não é possível cadastrar aluno");
                Close();
            } else {
                IList<string> query = (IList<string>)select;
                CB_Cidade.ItemsSource = query;
            }

            string modeString;
            switch(mode) {
                case "U":
                    modeString = "modificar";
                    break;
                case "I":
                    modeString = "inserir";

                    TB_Nome.Text = namePattern;
                    TB_Sobrenome.Text = lastNamePattern;
                    TB_CPF.Text = cpfPattern;

                    break;
                case "D":
                    modeString = "deletar";

                    TB_Nome.IsReadOnly = true;
                    TB_Sobrenome.IsReadOnly = true;
                    CB_Cidade.IsEnabled = false;
                    TB_CPF.IsReadOnly = true;
                    DP_Data.IsEnabled = false;

                    break;
                case "S":
                    modeString = "mostrar";

                    TB_Nome.IsReadOnly = true;
                    TB_Sobrenome.IsReadOnly = true;
                    CB_Cidade.IsEnabled = false;
                    TB_CPF.IsReadOnly = true;
                    DP_Data.IsEnabled = false;
                    B_Confirma.Visibility = Visibility.Hidden;

                    break;
                default:
                    modeString = "UNDEFINED";
                    break;
            }

            B_Confirma.Content = str.Capitalize(modeString);
        }

        private void GF_Nome(object sender, RoutedEventArgs e) {
            string[] commons = { namePattern };
            string[] messages = { "O nome do aluno", "não atende aos requisitos" };

            evt.Validate(common: commons, gotOrLost: "G", box: TB_Nome, message: messages,
                length: 75);
        }

        private void GF_Sobrenome(object sender, RoutedEventArgs e) {
            string[] commons = { lastNamePattern };
            string[] messages = { "O nome do sobrealuno", "não atende aos requisitos" };

            evt.Validate(common: commons, gotOrLost: "G", box: TB_Sobrenome, message: messages,
                length: 125);
        }

        private void GF_CPF(object sender, RoutedEventArgs e) {
            string[] commons = { cpfPattern };
            string[] messages = { "O CPF do aluno", "não atende aos requisitos" };

            evt.Validate(common: commons, gotOrLost: "G", box: TB_CPF, message: messages,
                length: 75, allowNull: true);
        }

        private void LF_Nome(object sender, RoutedEventArgs e) {
            string[] commons = { namePattern, nameLength, nameOnlyAlpha,
                                    "O nome do aluno", "não atende aos requisitos" };
            string[] messages = { "O nome do aluno", "não atende aos requisitos" };

            evt.Validate(box: TB_Nome, gotOrLost: "L", length: 75, common: commons, 
                message: messages, mask: new Regex(@"^[a-zA-Z]+$"));
        }

        private void LF_Sobrenome(object sender, RoutedEventArgs e) {
            string[] commons = { lastNamePattern, lastNameLength, lastNameOnlyAlpha,
                                    "O sobrenome do aluno", "não atende aos requisitos" };
            string[] messages = { "O sobrenome do aluno", "não atende aos requisitos" };

            evt.Validate(box: TB_Sobrenome, gotOrLost: "L", length: 125, common: commons, 
                message: messages, mask: new Regex(@"^[a-zA-Z]+$"));
        }

        private void LF_CPF(object sender, RoutedEventArgs e) {
            string[] commons = { cpfPattern, cpfLength, cpfMask,
                                    "O CPF", "não atende aos requisitos" };
            string[] messages = { "O CPF", "não atende aos requisitos" };

            evt.Validate(box: TB_CPF, gotOrLost: "L", length: 11, common: commons, 
                message: messages, mask: new Regex(@"\d{11}| "), 
                        allowNull: true);
        }
    }
}