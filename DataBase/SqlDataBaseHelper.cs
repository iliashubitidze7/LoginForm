using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
    public class SqlDataBaseHelper
    {
        private readonly string _connactionstring;

        public SqlDataBaseHelper(string connaction)
        {
            _connactionstring = connaction;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connactionstring);
        }

        public SqlCommand GetCommand(string commandText, CommandType comandType, params SqlParameter[] parameters)
        {
            SqlCommand command = GetConnection().CreateCommand();
            command.CommandText = commandText;
            command.CommandType = comandType;
            foreach (var p in parameters)
            {
                command.Parameters.Add(p);
            }
            return command;
        }

        public int ExecuteNonQuery(string commandText , CommandType commandType , params SqlParameter[] parameters)
        {
            var command = GetCommand(commandText, commandType, parameters);

            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public SqlDataReader ExecuteReader(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            var command = GetCommand(commandText, commandType, parameters );

            command.Connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
