using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAlunos.Entidades {
    class Aluno {
        StringManipulation str = new StringManipulation();

        private string name;
        private string lastName;
        private int codCity;
        private string cpf;
        private DateTime birthDate;

        public Aluno(string name, string lastName) {
            this.name = name;
            this.lastName = lastName;
        }

        public Aluno(string name, string lastName, int codCity, string cpf, DateTime birthDate) {
            this.name = name;
            this.lastName = lastName;
            this.codCity = codCity;
            this.cpf = cpf;
            this.birthDate = birthDate;
        }

        public string Name {
            get => name;
            set => name = str.Capitalize(value);
        }

        public string LastName {
            get => lastName;
            set => lastName = str.Capitalize(value);
        }

        public int CodCity { get => codCity; set => codCity = value; }

        public string Cpf {
            get => cpf;
            set {
                bool match = str.Mask(new Regex(@"(^\d{3}\x2E\d{3}\x2E\d{3}\x2D\d{2}$)"), value);

                if (match)
                    cpf = value;
                else
                    cpf = "I";
            }
        }

        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
    }
}
