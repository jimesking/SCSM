
namespace Entity
{
    public class UIInfomation
    {
        private int id;
        private string userName;
        private string caption;
        private string title;

        public UIInfomation() { }
        public UIInfomation(int id,string userName,string caption, string title)
        {
            this.Id = id;
            this.UserName = userName;
            this.caption = caption;
            this.title = title;
        }

        public string Caption
        {
            get
            {
                return caption;
            }

            set
            {
                caption = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }
}
