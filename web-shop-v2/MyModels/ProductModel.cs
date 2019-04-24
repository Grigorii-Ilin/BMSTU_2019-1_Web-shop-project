using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_shop_v2 {
    public class ProductModel {
        public string InsertProduct(Product product) {
            try {
                var db = new VegetableDBEntities();
                db.Product.Add(product);
                db.SaveChanges();
                return product.Name + " был успешно создан";
            }
            catch (Exception e) {

                return "Error" + e;
            }
        }

        public string UpdateProduct(int id, Product product) {
            try {
                var db = new VegetableDBEntities();
                var p = db.Product.Find(id);

                p.TypeId = product.TypeId;
                p.Name = product.Name;
                p.Price = product.Price;
                p.Description = product.Description;
                p.Image = product.Image;

                db.SaveChanges();
                return product.Name + " был успешно обновлён";
            }
            catch (Exception e) {

                return "Error" + e;
            }
        }

        public string DeleteProduct(int id) {
            try {
                var db = new VegetableDBEntities();
                var product = db.Product.Find(id);

                db.Product.Attach(product);
                db.Product.Remove(product);

                db.SaveChanges();
                return product.Name + " был успешно удалён";
            }
            catch (Exception e) {

                return "Error" + e;
            }
        }

        public Product GetProduct(int id) {
            try {
                using (var db = new VegetableDBEntities()) {
                    var product = db.Product.Find(id);
                    return product;
                }
            }
            catch (Exception) {

                return null;
            }
        }

        public List<Product> GetAllProducts() {
            try {
                using (var db = new VegetableDBEntities()) {
                    var products = (from x in db.Product
                                    select x).ToList();
                    return products;
                }
            }
            catch (Exception) {

                return null;
            }
        }

        public List<Product> GetProductsByType(int typeId) {
            try {
                using (var db = new VegetableDBEntities()) {
                    var products = (from x in db.Product
                                    where x.TypeId == typeId
                                    select x).ToList();
                    return products;
                }
            }
            catch (Exception) {

                return null;
            }
        }
    }
}