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
    public partial class CadastroAluno : Window {
        Oracle oracle = new Oracle();
        EventManipulation evt = new EventManipulation();
        private string mode;

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
                case "C":
                    modeString = "criar";
                    break;
                case "I":
                    modeString = "inserir";
                    break;
                case "D":
                    modeString = "deletar";
                    break;
                default:
                    modeString = "UNDEFINED";
                    break;
            }

            TB_Modo.Text = $"Modo: {modeString}";
        }

        private void LF_Nome(object sender, RoutedEventArgs e) {
            evt.Validate(box: TB_Nome, gotOrLost: "L", length: 75);
        }

        private void LF_Sobrenome(object sender, RoutedEventArgs e) {

        }

        private void LF_CPF(object sender, RoutedEventArgs e) {

        }
    }
}
