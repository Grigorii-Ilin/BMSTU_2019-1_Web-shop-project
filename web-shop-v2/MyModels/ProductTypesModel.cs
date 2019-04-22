using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_shop_v2 {
    public class ProductTypesModel {
        public string InsertProductTypes(ProductTypes productTypes) {
            try {
                var db = new VegetableDBEntities();
                db.ProductTypes.Add(productTypes);
                db.SaveChanges();
                return productTypes.Name + " был успешно создан";
            }
            catch (Exception e) {

                return "Error" + e;
            }
        }

        public string UpdateProductTypes(int id, ProductTypes productTypes) {
            try {
                var db = new VegetableDBEntities();
                var p = db.ProductTypes.Find(id);

                p.Name = productTypes.Name;

                db.SaveChanges();
                return productTypes.Name + " был успешно обновлён";
            }
            catch (Exception e) {

                return "Error" + e;
            }
        }

        public string DeleteProductTypes(int id) {
            try {
                var db = new VegetableDBEntities();
                var productTypes = db.ProductTypes.Find(id);

                db.ProductTypes.Attach(productTypes);
                db.ProductTypes.Remove(productTypes);

                db.SaveChanges();
                return productTypes.Name + " был успешно удалён";
            }
            catch (Exception e) {

                return "Error" + e;
            }
        }
    }
}