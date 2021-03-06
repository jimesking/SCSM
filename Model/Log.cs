﻿using System;

namespace Entity
{
    public class Log
    {
        private long id;
        private int type;
        private SensorAddress address;
        private DateTime time;
                
        private string description;

        public Log() { }
        public Log(long id, int type, SensorAddress address, string description)
        {
            this.Type = type;
            this.Address = address;           
            this.Description = description;
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
    }
}
