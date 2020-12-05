namespace  LoSpacoWebAPi.Models {
    public class Customer {
        public uint Id { get; private set; }
        public Account Account { get; private set; }
        public string Username { get; private set; }
        public string FullName { get; private set; }
        public string CPF { get; private set; }
        public string Phone { get; private set; }
        public Customer(Account account, string username, string fullName, string cPF, string phone)
        {
            Account = account;
            Username = username;
            FullName = fullName;
            CPF = cPF;
            Phone = phone;
        }

        public Customer() { }
    }
}