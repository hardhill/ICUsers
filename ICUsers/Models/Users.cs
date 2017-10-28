using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICUsers.Models
{
    public class Users
    {
        private UsersContext usersConectext;
        public string Id_tabel { get; set; }
        public int Id_otdel { get; set; }
        public string FIO { get; set; }
        public int Id_norma { get; set; }
        public int Id_role { get; set; }
        public bool Actived { get; set; }
    }
}
