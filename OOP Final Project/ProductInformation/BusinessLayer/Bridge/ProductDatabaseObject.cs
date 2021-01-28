using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Bridge
{
    public class ProductDatabaseObject : IDatabaseObject<Product>
    {

        private ProductInformationEntities db = new ProductInformationEntities();
        private List<Product> _products;
        private int _current = 0;
        public ProductDatabaseObject()
        {
            _products = db.Products.ToList();
        }

        public Product Next
        {
            get
            {
                if (_current < _products.Count - 1)
                    _current++;
                return _products[_current];
            }
        }

        public Product Prior
        {
            get
            {
                if (_current > 0)
                    _current--;
                return _products[_current]; ;
            }
        }

        public List<Product> ShowAll()
        {
            return _products;
        }
    }

    public class ProductBase
    {
        public IDatabaseObject<Product> DataObject { get; set; }
        public Product Prior { get { return DataObject.Prior; } }
        public Product Next { get { return DataObject.Next; } }
        public List<Product> ShowAll() { return DataObject.ShowAll(); }
    }
}
