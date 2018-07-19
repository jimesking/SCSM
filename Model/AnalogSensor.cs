namespace Entity
{
    public class AnalogSensor: Sensor
    {
        private string format;

        private double md;
        private double mu;

        private string ut;

        private double h4l;
        private double h3l;
        private double h2l;
        private double h1l;

        private double l1l;
        private double l2l;
        private double l3l;
        private double l4l;

        public string Format
        {
            get
            {
                return format;
            }

            set
            {
                format = value;
            }
        }

        public double Md
        {
            get
            {
                return md;
            }

            set
            {
                md = value;
            }
        }

        public double Mu
        {
            get
            {
                return mu;
            }

            set
            {
                mu = value;
            }
        }

        public double H4l
        {
            get
            {
                return h4l;
            }

            set
            {
                h4l = value;
            }
        }

        public double H3l
        {
            get
            {
                return h3l;
            }

            set
            {
                h3l = value;
            }
        }

        public double H2l
        {
            get
            {
                return h2l;
            }

            set
            {
                h2l = value;
            }
        }

        public double H1l
        {
            get
            {
                return h1l;
            }

            set
            {
                h1l = value;
            }
        }

        public double L1l
        {
            get
            {
                return l1l;
            }

            set
            {
                l1l = value;
            }
        }

        public double L2l
        {
            get
            {
                return l2l;
            }

            set
            {
                l2l = value;
            }
        }

        public double L3l
        {
            get
            {
                return l3l;
            }

            set
            {
                l3l = value;
            }
        }

        public double L4l
        {
            get
            {
                return l4l;
            }

            set
            {
                l4l = value;
            }
        }

        public string Ut
        {
            get
            {
                return ut;
            }

            set
            {
                ut = value;
            }
        }
    }
}
