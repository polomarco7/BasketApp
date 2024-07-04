using BasketApp.Models;
using ShopApp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace BasketApp.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        ApplicationContext db = new ApplicationContext();

        private Product product = new();
        private Basket basket = new();

        public ObservableCollection<Product> Products { get; set; } = [];
        public ObservableCollection<HistList> HistList { get; set; } = [];
        public ObservableCollection<Basket> Baskets { get; set; } = [];

        public MainWindowViewModel()
        {
            GetProducts();
            ICollectionView view = CollectionViewSource.GetDefaultView(HistList);
            view.GroupDescriptions.Add(new PropertyGroupDescription("Date"));
            view.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));
            GetHistory();
            Baskets = new ObservableCollection<Basket>();

        }

        public void AddProductToBasket(string name, int productId)
        {
            Baskets.Add(new Basket { Name = name, Count = 1, Price = 0, ProductId = productId});
        }
        public void GetProducts()
        {
            using (db)
            {
                var products = db.Products.Where(p => p.InStock == true).ToList();
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
        }
        public void GetHistory()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var products = from product in db.Products
                               join basket in db.BasketProductCards on product.Id equals basket.ProductId
                               join history in db.Histories on basket.HistoryId equals history.Id
                               select new
                               {
                                   Name = product.Name,
                                   Count = basket.Count,
                                   Price = basket.Price,
                                   TotalAmount = history.TotalAmount,
                                   Date = history.Date,
                                   BasketId = basket.Id,
                                   HistId = history.Id
                               };

                var g = products.ToList().GroupBy(p => p.HistId).ToList();

                foreach(var item in g)
                {
                    var date = item.Key;
                    foreach(var product in item)
                    {
                        HistList.Add(new HistList { Name = product.Name, Count = product.Count, Price = product.Price, Date = product.Date, TotalAmount = product.TotalAmount });
                    }
                    
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
