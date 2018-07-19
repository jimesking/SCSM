using System.Collections.Generic;

namespace Entity
{
    public class User
    {
        private string name;

        private string password;

        private int role; //1:admin 2：op 3：guest

        public User() { }
        public User(string name, string password, int role) {
            this.name = name;
            this.password = password;
            this.role = role;
        }
        public User(string name, string password)
        {
            this.name = name;
            this.Password = password;
        }
        public User(string name) {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }


        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
    }
}
