using BasketApp.Models;
using ShopApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp
{
    public class DirectoryCollection : ObservableCollection<Product>
    {
        public void Add(string name)
        {            
            this.Add(new Product { Name = name, InStock = true });
        }
    }
}
