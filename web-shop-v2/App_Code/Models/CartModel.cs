using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_shop_v2.App_Code.Models {
    public class CartModel {
        public string InsertCart(Cart cart) {
            try {
                var db = new VegetableDBEntities();
                db.Cart.Add(cart);
                db.SaveChanges();
                return cart.DatePurchased + " was successfully inserted";
            }
            catch (Exception e) {

                return "Error"+e;
            }
        }

        public string UpdateCart(int id, Cart cart) {
            try {
                var db = new VegetableDBEntities();
                var p = db.Cart.Find(id);

                p.ClientId = cart.ClientId;
                p.ProductId = cart.ProductId;
                p.Amount = cart.Amount;
                p.DatePurchased = cart.DatePurchased;
                p.IsInCart = cart.IsInCart;

        db.SaveChanges();
                return cart.DatePurchased + " was successfully updated";
            }
            catch (Exception e) {

                return "Error" + e;
            }
        }

        public string DeleteCart(int id) {
            try {
                var db = new VegetableDBEntities();
                var cart = db.Cart.Find(id);

                db.Cart.Attach(cart);
                db.Cart.Remove(cart);

                db.SaveChanges();
                return cart.DatePurchased + " was successfully deleted";
            }
            catch (Exception e) {

                return "Error" + e;
            }
        }
    }
}