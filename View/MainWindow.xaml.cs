using System.Collections.ObjectModel;
using System.Windows;
using BasketApp.Models;
using BasketApp.ViewModel;
using ShopApp;

namespace BasketApp
{
    public partial class MainWindow : Window
    {
        public delegate void RefreshList();
        public event RefreshList? RefreshListEvent = null;
        MainWindowViewModel ViewModel = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            RefreshListView();
            basketListBox.ItemsSource = ViewModel.Baskets;

        }
        private void RefreshListView()
        {
            DataContext = new MainWindowViewModel();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DirectoryWindow directoryWindow = new DirectoryWindow();
            RefreshListEvent += new RefreshList(RefreshListView);
            directoryWindow.UpdateActor = RefreshListEvent;
            directoryWindow.Show();
        }

        private void addToBasketBtn_Click(object sender, RoutedEventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("d");

             var productName = productListBox.SelectedItems.Cast<Product>().Select(x => x).FirstOrDefault();
            ViewModel.AddProductToBasket(productName!.Name!, productName.Id);
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Baskets.Clear();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Histories.Add(new History { Date = DateTime.Now.Date, TotalAmount = ViewModel.Baskets.Sum(x=>x.TotalPrice) });
                db.SaveChanges();
                
                var id = db.Histories.OrderBy(p => p.Id).Select(x => x.Id).LastOrDefault();
                foreach (var item in ViewModel.Baskets)
                {
                    var basketProductCard = new BasketProductCard();
                    basketProductCard.ProductId = item.ProductId;
                    basketProductCard.Price = item.Price;
                    basketProductCard.Count = item.Count;
                    basketProductCard.HistoryId = id;
                    db.BasketProductCards.Add(basketProductCard);
                    db.SaveChanges();
                }
                
            }
            ViewModel.Baskets.Clear();
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            HistList histList = (HistList)historyList.SelectedItem;
        }

        private void basketListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Basket b = (Basket)basketListBox.SelectedItem;
        }
    }
}
