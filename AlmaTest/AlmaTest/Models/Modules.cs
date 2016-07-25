using System.ComponentModel.DataAnnotations;

namespace AlmaTest.Models
{
    public class Modules
    {
        // Properties
        private string _module;
        public string Module
        {
            get
            {
                return _module;
            }
            set
            {
                _module = value;
            }
        }
        private decimal _price;
        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        private bool _kernel;
        public bool Kernel
        {
            get
            {
                return _kernel;
            }
            set
            {
                _kernel = value;
            }
        }
        
        private int _position;
        [Key]
        public int Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        // Constructors
        public Modules() { }
        public Modules(string module, decimal price, bool kernel, int position)
        {
            Module = module;
            Price = price;
            Kernel = kernel;
            Position = position;
        }

    }
}