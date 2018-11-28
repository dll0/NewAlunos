using System;
using System.Collections.Generic;
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
    class EventManipulation {
        public void Focus(string gotOrLost, TextBox box = null, PasswordBox passBox = null,
                            Regex mask = null, bool showErrors = false, string[] common = null, string[] message = null) {

            if (box != null) {
                string str = box.Text;
                string strNoSpace = str.Replace(" ", String.Empty);

                if (gotOrLost.Equals("G")) {
                    FocusAndSelectAll(box: box);

                    if (strNoSpace.Equals(String.Empty)) {
                        box.Text = common[0];
                    } else if (str.Equals(common[0])) {
                        box.Text = String.Empty;
                    }
                } else if (gotOrLost.Equals("L")) {
                    bool onlyCharactersDefined = mask.IsMatch(str);
                    bool equalsToCommon = false;

                    for (int i = 0; i < common.Length; i++) {
                        if (str.Equals(common[i])) {
                            equalsToCommon = true;
                            break;
                        }
                    }

                    if (strNoSpace.Equals(String.Empty)) {
                        box.Text = common[0];
                    } else if (str.Length > 8
                            && !equalsToCommon) {
                        MessageBox.Show($"{common[1]}{Environment.NewLine}{message[0]} '{str}' {message[1]}");
                        box.Text = common[1];

                        FocusAndSelectAll(box: box);
                    } else if (!onlyCharactersDefined
                            && !equalsToCommon) {
                        box.Text = common[2];
                        int position = 0;
                        List<string> changes = new List<string>();

                        foreach (char letter in str) {
                            position++;
                            if (!mask.IsMatch(Convert.ToString(letter))) {
                                changes.Add($"{Convert.ToString(position)}: {Convert.ToString(letter)}; ");
                            }
                        }

                        string changesToDo = string.Join(" ", changes);

                        if (showErrors) {
                            MessageBox.Show($"{message[0]} '{str}' {message[1]}" +
                                    $"{Environment.NewLine}" +
                                    $"Caracteres invalidos em suas posições:" +
                                    $"{Environment.NewLine}{changesToDo}");
                        }

                        FocusAndSelectAll(box: box);
                    }
                }
            } else if (passBox != null) {
                string pass = passBox.Password.ToString();
                string passNoSpace = pass.Replace(" ", String.Empty);
                bool haveOnlyNumeric = mask.IsMatch(pass);
                bool isBlank = passNoSpace.Equals(String.Empty);

                if (gotOrLost.Equals("G")) {
                } else if (gotOrLost.Equals("L")) {
                    if (pass.Length > 5) {
                        MessageBox.Show($"{message[0]} '{pass}' {message[1]}" +
                                        $"{Environment.NewLine}" +
                                        $"{message[2]}");

                        FocusAndSelectAll(passBox: passBox);
                    } else if (!haveOnlyNumeric && !isBlank) {
                        List<char> changes = new List<char>();

                        foreach (char letter in pass) {
                            if (!mask.IsMatch(letter.ToString())) {
                                changes.Add(letter);
                            }
                        }

                        string changesToDo = string.Join("; ", changes);

                        if (showErrors) {
                            MessageBox.Show($"Os seguintes caracteres inválidos foram encontrados:" +
                                        $"{Environment.NewLine}" +
                                        $"{changesToDo};");
                        }

                        FocusAndSelectAll(passBox: passBox);
                    }
                }
            }
        }

        private static void FocusAndSelectAll(TextBox box = null, PasswordBox passBox = null) {
            if (box != null) {
                Task.Delay(100).ContinueWith(_ => {
                    Application.Current.Dispatcher.Invoke(new Action(() => {
                        box.Focus();
                        box.SelectAll();
                    }));
                });
            } else {
                Task.Delay(100).ContinueWith(_ => {
                    Application.Current.Dispatcher.Invoke(new Action(() => {
                        passBox.Focus();
                        passBox.SelectAll();
                    }));
                });
            }
        }
    }
}
