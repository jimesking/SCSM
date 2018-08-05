
namespace Entity
{
    public class Module
    {
        private string name;
        private SensorAddress address;
        private string description;
        private int anaSensorCount;
        private int digSensorCount;

        public Module() { }
        public Module(string name, SensorAddress address, string description, int anaSensorCount, int digSensorCount) {
            this.Name = name;
            this.Address = address;
            this.Description = description;
            this.AnaSensorCount = anaSensorCount;
            this.DigSensorCount = digSensorCount;
        }
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

        public int AnaSensorCount
        {
            get
            {
                return anaSensorCount;
            }

            set
            {
                anaSensorCount = value;
            }
        }

        public int DigSensorCount
        {
            get
            {
                return digSensorCount;
            }

            set
            {
                digSensorCount = value;
            }
        }
    }
}
