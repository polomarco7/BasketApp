using System.ComponentModel;

namespace BasketApp.Models
{
    internal class HistList : INotifyPropertyChanged
    {
        private string? name;
        public string? Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }
        public int Count { get; set; }
        public int Price { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public int TotalAmount { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
