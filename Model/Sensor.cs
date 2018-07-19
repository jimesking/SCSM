namespace Entity
{
    public class Sensor
    {
        //静态信息
        protected string name;

        protected SensorAddress address;

        protected string description;

        protected int interval = 60;

        public SensorAddress Address
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

        public int Interval
        {
            get
            {
                return interval;
            }

            set
            {
                interval = value;
            }
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
    }
}
