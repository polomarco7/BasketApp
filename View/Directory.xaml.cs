using BasketApp.Models;
using ShopApp;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BasketApp
{
    public partial class DirectoryWindow : Window
    {
        public DirectoryCollection Products { get; } = [];
        public Delegate? UpdateActor = null;
        public DirectoryWindow()
        {            
            InitializeComponent();
            this.DataContext = this;

            using (ApplicationContext db = new ApplicationContext())
            {
                var products = db.Products.ToList();
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listViewDirectory.ItemsSource = Products);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(TxtboxNewItem.Text))
                return true;
            else
                return ((item as Product)!.Name!.IndexOf(TxtboxNewItem.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            UpdateActor!.DynamicInvoke();
            this.Close();
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (Products.Any(p => p.Name == TxtboxNewItem.Text))
            {
                MessageBox.Show("Уже есть в списке");
                return;
            }

            Products.Add(TxtboxNewItem.Text);

            using (ApplicationContext db = new())
            {
                db.Products.Add(new Product { Name = TxtboxNewItem.Text, InStock = true});
                db.SaveChanges();
            }
            UpdateActor!.DynamicInvoke();
            TxtboxNewItem.Clear();
            TxtboxNewItem.Focus();
        }

        private void TxtboxNewItem_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listViewDirectory.ItemsSource).Refresh();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Product product = (Product)((CheckBox)sender).DataContext;
            product.InStock = true;
            using (ApplicationContext db = new())
            {
                db.Products.Update(product);
                db.SaveChanges();
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Product product = (Product)((CheckBox)sender).DataContext;
            product.InStock = false;
            using (ApplicationContext db = new())
            {
                db.Products.Update(product);
                db.SaveChanges();
            }
        }
    }
}
