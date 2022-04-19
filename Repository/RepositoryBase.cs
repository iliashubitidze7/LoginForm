using DataBase;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UserRepository;


namespace Repository
{
    public class RepositoryBase
    {
        protected readonly string _connectionString;
        protected readonly SqlDataBaseHelper _dataBase;

        public RepositoryBase()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AppDB"].ConnectionString;
            _dataBase = new SqlDataBaseHelper(_connectionString);
        }

        public void Insert(User user)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@FirstName" , user.FirstName),
                                                             new SqlParameter("@LastName" , user.LastName)
            };

            _dataBase.ExecuteNonQuery("InsertUser_SP" , CommandType.StoredProcedure , parameters);
        }

        public User ReadUser()
        {
            User user = new User();

            SqlDataReader reader = _dataBase.ExecuteReader("GetUser_Sp" ,CommandType.StoredProcedure);

            while (reader.Read())
            {
                user.Id = (int)reader["Id"];
                user.FirstName = reader["FirstName"].ToString();
                user.LastName = reader["lastName"].ToString();
            }

            return user;
        }

        
    }
}
