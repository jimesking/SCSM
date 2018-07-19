
using System.Collections.Generic;

namespace Entity
{
    public class Station
    {
        string name;
        SensorAddress address;
        private string description;
        private int moduleCount;

        public Station() { }
        public Station(string name , SensorAddress address, string description, int moduleCount)
        {
            this.name = name;
            this.address = address;
            this.description = description;
            this.ModuleCount = moduleCount;
        }

        public static bool operator ==(Station a, Station b) {
            if ( a.Name == b.Name && a.Address.ToString() == b.Address.ToString() && a.Description == b.Description)
            {
                return true;
            }else {
                return false;
            }                 
        }
        public static bool operator !=(Station a, Station b)
        {
            if (a.Name != b.Name || a.Address.ToString() != b.Address.ToString() || a.Description != b.Description)
            {
                return true;
            }
            else
            {
                return false;
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

        public int ModuleCount
        {
            get
            {
                return moduleCount;
            }

            set
            {
                moduleCount = value;
            }
        }
    }
}
