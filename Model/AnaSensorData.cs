using System;
namespace Entity
{
    public class AnaSensorData
    {
        private string name;
        private DateTime time;
        private bool q;
        private double av;

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

        public bool Q
        {
            get
            {
                return q;
            }

            set
            {
                q = value;
            }
        }

        public double Av
        {
            get
            {
                return av;
            }

            set
            {
                av = value;
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
        public AnaSensorData() { }
        public AnaSensorData(string name, bool q, double av)
        {
            this.Name = name;
            this.Q = q;
            this.Av = av;
        }
    }
}
