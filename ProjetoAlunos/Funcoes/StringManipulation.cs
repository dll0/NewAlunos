using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAlunos
{
    class StringManipulation
    {
        public string Capitalize (string str) {
            string result = String.Empty;

            str.Split();
            char first = str[0];
            result += first.ToString().ToUpper();

            for (int i = 1; i < str.Length; i++) {
                result += str[i].ToString().ToLower();
            }

            return result;
        }
    }
}
