namespace PassoLeagueSystem
{
    public abstract class User
    {
        private string userName;
        private int password;
        
        protected User(string userName, int password)
        {
            this.userName = userName;
            this.password = password;
        }

        public string UserName
        {
            get => userName;
            set => userName = value;
        }

        public int Password
        {
            get => password;
            set => password = value;
        }
        public abstract void searchFromIDAndDisplayTicket(int ID);
    }
}