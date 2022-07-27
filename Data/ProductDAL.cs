using CRUDusingentityframework.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRUDusingentityframework.Data
{
    public class ProductDAL
    {
        ApplicationDbContext db;

        public ProductDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Product> GetAllProduct()
        {
            return db.Product.ToList();
        }
        //public IEnumerable<Product> GetAllProducts()
        //{
        //    return from p in db.Products select p;
        //}

        /*public IQueryable<Product> GetAllProducts()
        {
          return from p in db.Product select p;
        }*/

        public Product GetProductById(int id)
        {
            Product p = db.Product.Where(x => x.Id == id).FirstOrDefault();
            return p;
        }

        public int AddProduct(Product prod)
        {

            // add prod object in the produts collections
            db.Product.Add(prod);
            // reflect the change in DB
            int result = db.SaveChanges();
            return result;
        }

        public int UpdateProduct(Product prod)
        {
            int result = 0;
            // p object hold old data
            Product p = db.Product.Where(x => x.Id == prod.Id).FirstOrDefault();
            if (p != null)
            {
                p.Name = prod.Name;
                p.Price = prod.Price;
                result = db.SaveChanges();
            }
            return result;
        }

        public int DeleteProduct(int id)
        {
            int result = 0;
            Product p = db.Product.Where(x => x.Id == id).FirstOrDefault();
            if (p != null)
            {
                db.Product.Remove(p);
                result = db.SaveChanges();
            }
            return result;
        }
    }
    }

