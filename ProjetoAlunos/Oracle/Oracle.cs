using System;
using System.Windows;
using Oracle.ManagedDataAccess.Client;
using System.IO;
using System.Data;

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

        public string Query(string query, string returnType, bool hasMultipleResult) {
            OracleCommand command = new OracleCommand(query, connection);

            if (returnType.Equals("S")) {
                /* String */
                try {
                    command.CommandType = CommandType.Text;
                    OracleDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();
                    if (dataReader.HasRows) {
                        return dataReader.GetString(0);
                    } else {
                        return "-1";
                    }
                }
                catch {
                    return "-1";
                }
            } else if (returnType.Equals("I")) {
                /* Integer */
                try {
                    command.CommandType = CommandType.Text;
                    OracleDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();
                    if (dataReader.HasRows) {
                        return Convert.ToString(dataReader.GetInt32(0));
                    } else {
                        return "-1";
                    }
                }
                catch {
                    return "-1";
                }
            } else {
                return "-1";
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

