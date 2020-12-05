using  LoSpacoWebAPi.Models;
using  LoSpacoWebAPi.Security;

namespace  LoSpacoWebAPi.DAO {
    public abstract class AccountDAO {
        private static Database db = new Database();
        public static Account GetByEmail(string email) {
            var row = db.ReaderRow(db.ReturnCommand($"select * from tbLogin where LoginEmail = '{email}'"));
            Account account = new Account((uint)row[0], (string)row[1], RoleDAO.GetById((byte)row[3]));
            return account;
        }

        public static Account GetById(uint id)
        {
            var row = db.ReaderRow(db.ReturnCommand($"select * from tbLogin where LoginId = '{id}'"));
            return new Account((uint)row[0], (string)row[1], RoleDAO.GetById((byte)row[3]));
        }
        public static dynamic Insert(string email, string password) {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, 12);
            object[] data = db.ReaderAllValue(db.ReturnProcedure("sp_InsertLogin", email, passwordHash));
            return new { Type = data[0], Value = data[1] };
        }

        public static bool Login(string email, string password) {
            string query = $"select LoginPass from tbLogin where LoginEmail = '{email}'";
            object currentPassword = db.ReaderValue(db.ReturnCommand(query));
            if (currentPassword == null) return false;
            return BCrypt.Net.BCrypt.Verify(password, currentPassword.ToString());
        }

        public static dynamic UpdatePassword(uint id, string currentPassword, string newPassword) {
            string query = $"select LoginPass from tbLogin where loginid = '{id}'";
            object currentPasswordHashFromDB = db.ReaderValue(db.ReturnCommand(query));
            bool passwordMatches = BCrypt.Net.BCrypt.Verify(currentPassword, currentPasswordHashFromDB.ToString());
            if (passwordMatches) {
                string newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword, 12);
                db.ExecuteCommand($"update tbLogin set LoginPass='{newPasswordHash}' where loginid='{id}'");
                return new { message = "Senha atualizada com sucesso!", index = 0 };
            } else {
                return new { message = "Senha atual incorreta!", index = 2 };
            }
        }

        public static bool RegistrationCompleted(uint id) => db.HasRows(db.ReturnCommand($"select * from tbcustomer where loginid={id}"));

    }
}