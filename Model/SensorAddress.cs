namespace Entity
{
    public class SensorAddress
    {
        string userName;
        string stationName;
        string moduleName;
        int channal;

        public SensorAddress() { }
        public SensorAddress(string address) {

            string[] strs= address.Split('.');

            if (strs.Length < 1) {
                this.UserName = "";
                this.StationName = "";
                this.ModuleName = "";
                this.channal = 0;
            }
            if (strs.Length == 1)
            {
                this.UserName = address;
            }
            if (strs.Length ==2)
            {
                this.UserName = strs[0];
                this.StationName = strs[1];
            }
            if (strs.Length ==3 )
            {
                this.UserName = strs[0];
                this.StationName = strs[1];
                this.ModuleName = strs[2];
            }
            if (strs.Length > 3)
            {
                this.UserName = strs[0];
                this.StationName = strs[1];
                this.ModuleName = strs[2];
                this.channal = int.Parse(strs[3]);
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

        public string StationName
        {
            get
            {
                return stationName;
            }

            set
            {
                stationName = value;
            }
        }

        public string ModuleName
        {
            get
            {
                return moduleName;
            }

            set
            {
                moduleName = value;
            }
        }

        public int Channal
        {
            get
            {
                return channal;
            }

            set
            {
                channal = value;
            }
        }
        /// <summary>
        /// 将地址以 userName.stationName.moduleName.channal格式返回
        /// </summary>
        /// <returns>返回地址</returns>
        public override string ToString() {
            string address = "";

            if (this.UserName == "")
                return "";
            else
                address = this.UserName;

            if (this.StationName == "")
                return address;
            else
                address = this.UserName + "." + this.StationName;

            if (this.ModuleName == "")
                return address;
            else
                address = address + "." + this.ModuleName;

            if (this.Channal < 0)
                return address;
            else
                address = address + "." + this.Channal.ToString();

            return address;
        }
    }
}
