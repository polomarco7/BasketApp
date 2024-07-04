using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BasketApp.Models
{
    public class Basket : INotifyPropertyChanged
    {
        string? name;
        int count;
        int price;
        int totalPrice;

        public int ProductId { get; set; }
        public string? Name 
        { 
            get { return  name; }
            set 
            { 
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }
        public int Price 
        {
            get { return price; }
            set 
            {
                price = value;
                OnPropertyChanged("Price");
            }            
        }

        public int TotalPrice
        {
            get { return Count * Price; }
            set
            {
                if (totalPrice != value)
                {
                    totalPrice =value;
                    OnPropertyChanged("TotalPrice");
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
