using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; // şimdilik sanal veri tabanı in memory
        public InMemoryProductDal()
        {
            _products = new List<Product> { 
                new Product {CategoryId=1,ProductID=1,ProductName="bardak",UnitInStock=15,UnitPrice=15},
                new Product {CategoryId=2,ProductID=1,ProductName="kamera",UnitInStock=500,UnitPrice=3},
                new Product {CategoryId=3,ProductID=2,ProductName="telefon",UnitInStock=1500,UnitPrice=2},
                new Product {CategoryId=4,ProductID=2,ProductName="klavye",UnitInStock=150,UnitPrice=65},
                new Product {CategoryId=5,ProductID=2,ProductName="dare",UnitInStock=85,UnitPrice=1}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {

            // Product prodel = null;

            //foreach (var item in _products)
            //{
            //    if (product.ProductID == product.ProductID)
            //    {
            //        prodel = prodel;
            //    }
            //}


            Product prodel =  _products.SingleOrDefault(p=>p.ProductID == product.ProductID);
            _products.Remove(prodel);

            
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            // listedeki gönderilen ürün [product] idsine sahip  olan listedeki ürünü bul

            Product proup = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            proup.ProductName = product.ProductName;
            proup.UnitPrice = product.UnitPrice;
            proup.UnitInStock = product.UnitInStock;
            proup.CategoryId = product.CategoryId;
            //.... tüm özellikleri burada gönderdiğin [product] özeliiklerine göre günceller gönderdiğin ID deki liste ürününde günceller  >> DBde (listede) kayıtlı proup ürününü product gönderdiğin product ürünü ile güncelle.
        }

        // son eklenen kategori listesindeki tüm ürünler
        public List<Product> GetByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();

        }
    }
}
