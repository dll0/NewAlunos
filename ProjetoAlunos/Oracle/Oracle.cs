using System;
using System.Windows;
using Oracle.ManagedDataAccess.Client;
using System.IO;
using System.Data;
using System.Collections.Generic;

namespace ProjetoAlunos {
    class Oracle {
        OracleConnection connection = new OracleConnection();

        public bool Connect() {
            connection.ConnectionString = "User Id=matheus;Password=123;Data Source=SISTEMAALUNO;DBA Privilege=SYSDBA";

            try {
                connection.Open();
                return true;
            }
            catch {
                return false;
            }
        }

        public void Close() {
            connection.Close();
            connection.Dispose();
        }

        public string getVersao() {
            return connection.ServerVersion;
        }

        public bool Script(string caminhoArquivo) {
            var script = File.ReadAllText(caminhoArquivo);

            OracleCommand command = new OracleCommand(script, connection);

            try {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                command.Dispose();
                return true;
            }
            catch {
                return false;
            }
        }

        public List<string> Query(string query) {
            OracleCommand command = new OracleCommand(query, connection);
            List<string> queries = new List<string>();

            try {
                command.CommandType = CommandType.Text;
                OracleDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read()) {
                    queries.Add(dataReader["nome"].ToString());
                    queries.Add(dataReader["senha"].ToString());
                }

                return queries;
            }
            catch {
                return queries = new List<string> { "-1" };
            }
        }

        public bool Insert(string sql) {
            OracleCommand command = new OracleCommand(sql, connection);

            try {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                command.Dispose();
                return true;
            }
            catch {
                return false;
            }
        }
    }
}

