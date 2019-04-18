using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_shop_v2.App_Code.Models {
    public class ProductModel {
        public string InsertProduct(Product product) {
            try {
                var db = new VegetableDBEntities();
                db.Product.Add(product);
                db.SaveChanges();
                return product.Name + " was successfully inserted";
            }
            catch (Exception e) {

                return "Error"+e;
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
                return product.Name + " was successfully updated";
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
                return product.Name + " was successfully deleted";
            }
            catch (Exception e) {

                return "Error" + e;
            }
        }
    }
}