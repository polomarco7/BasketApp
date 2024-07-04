using System.ComponentModel;

namespace BasketApp.Models
{
    public class Product : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public bool InStock { get; set; }

        private string? _name;

        public string? Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
