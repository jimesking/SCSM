
namespace Entity
{
    public class UIInfomation
    {
        private string userName;
        private string caption;
        private string title;

        public UIInfomation(string userName,string caption, string title)
        {
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
    }
}
