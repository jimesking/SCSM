using System;

namespace Entity
{
    public class Alarm
    {
        private long id;
        private int type;
        private string address;
        private System.DateTime time;
        private string description;

        public long Id
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

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public DateTime Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public Alarm() { }
        public Alarm(int id)
        {
            this.Id = id;
        }
        public Alarm( int type, string address, string description)
        {
            this.Type = type;
            this.Address = address;

            this.Description = description;
        }
    }
}
