﻿using System;

namespace Entity
{
    public class DigSensorData
    {
        private long id;
        private string name;
        private DateTime time;
        private bool q;
        private bool dv;

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

        public bool Dv
        {
            get
            {
                return dv;
            }

            set
            {
                dv = value;
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
        public DigSensorData() { }

        public DigSensorData(long id,string name, bool q, bool dv)
        {
            this.Name = name;
            this.Q = q;
            this.Dv = dv;
        }
    }
}
