
namespace Entity
{
    public class DigitalSensor:Sensor
    {
        public DigitalSensor() { }
        public DigitalSensor(string name,string address,string description,int interval) {
            this.Name = name;
            this.Address = new SensorAddress(address);
            this.Description = description;
            this.Interval = Interval;
        }
    }
}
