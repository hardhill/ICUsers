using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ICUsers.Models
{
    public class UsersContext
    {
        public string ConnectionString { get; set; }
        public UsersContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Users> GetAllUsers()
        {
            List<Users> list = new List<Users>();
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM USERS";
                    MySqlCommand comUsersAll = new MySqlCommand(sql, conn);
                    using(MySqlDataReader readUser= comUsersAll.ExecuteReader())
                    {
                        while (readUser.Read())
                        {
                            list.Add(new Users()
                            {
                                Id_tabel = readUser.GetString("id_tabel"),
                                Id_otdel = readUser.IsDBNull(1) ? 0 : readUser.GetInt32("id_otdel"),
                                FIO = readUser.GetString("FIO"),
                                Id_norma = readUser.IsDBNull(3)?0:readUser.GetInt32("id_norma"),
                                Id_role = readUser.IsDBNull(4)?0:readUser.GetInt32("id_norma"),
                                Actived = (readUser.GetInt16("Actived")==0)?false:true
                            } );
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
                
            }
         return list;
        }
    }
}