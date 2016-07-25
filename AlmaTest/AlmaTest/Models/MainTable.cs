using System;

namespace AlmaTest.Models
{
    public class MainTable
    {
        private int _id;
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        private string _client;
        public string Client
        {
            get
            {
                return _client;
            }
            set
            {
                _client = value;
            }
        }
        private string _distributor;
        public string Distributor
        {
            get
            {
                return _distributor;
            }
            set
            {
                _distributor = value;
            }
        }
        private string _baza;
        public string Baza
        {
            get
            {
                return _baza;
            }
            set
            {
                _baza = value;
            }
        }
        private string _note;
        public string Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
            }
        }
        private DateTime? _date;
        public DateTime? Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }
        private string _progKey;
        public string ProgKey
        {
            get
            {
                return _progKey;
            }
            set
            {
                _progKey = value;
            }
        }
        private string _pass;
        public string Pass
        {
            get
            {
                return _pass;
            }
            set
            {
                _pass = value;
            }
        }
        private bool? _accOffice;
        public bool? AccOffice
        {
            get
            {
                return _accOffice;
            }
            set
            {
                _accOffice = value;
            }
        }
        private string _txtMod;
        public string TxtMod
        {
            get
            {
                return _txtMod;
            }
            set
            {
                _txtMod = value;
            }
        }
        private string _txtPrice;
        public string TxtPrice
        {
            get
            {
                return _txtPrice;
            }
            set
            {
                _txtPrice = value;
            }
        }
        private int? _modules;
        public int? Modules
        {
            get
            {
                return _modules;
            }
            set
            {
                _modules = value;
            }
        }
        private int? _firmi;
        public int? Firmi
        {
            get
            {
                return _firmi;
            }
            set
            {
                _firmi = value;
            }
        }
        private int? _rabMesta;
        public int? RabMesta
        {
            get
            {
                return _rabMesta;
            }
            set
            {
                _rabMesta = value;
            }
        }
        private string _hostName;
        public string HostName
        {
            get
            {
                return _hostName;
            }
            set
            {
                _hostName = value;
            }
        }

        // Constructors
        public MainTable() { }

        // Methods
        public bool[] GenerateModules()
        {
            bool[] modules = new bool[32];
            long code = long.Parse(TxtMod);

            for(int i = 0; i < 32; i++)
            {
                modules[i] = (code & 1 << i) != 0;
            }

            return modules;
        }
    }
}