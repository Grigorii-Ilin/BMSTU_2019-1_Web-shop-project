using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_shop_v2 {
    public class CartModel {
        public string InsertCart(Cart cart) {
            try {
                var db = new VegetableDBEntities();
                db.Cart.Add(cart);
                db.SaveChanges();
                return cart.DatePurchased + " товар был успешно добавлен в корзину";
            }
            catch (Exception e) {

                return "Error" + e;
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
                return cart.DatePurchased + " товар был успешно обновлён в корзине";
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
                return cart.DatePurchased + " товар был успешно удален из корзины";
            }
            catch (Exception e) {

                return "Error" + e;
            }
        }

        public List<Cart> GetOrdersInCart(string userId) {
            var db = new VegetableDBEntities();
            var orders = (from x in db.Cart
                          where x.ClientId == userId && x.IsInCart
                          orderby x.DatePurchased
                          select x).ToList();
            return orders;
        }

        public void MarkOrdersAsPurchased(List<Cart> orders) {
            var db = new VegetableDBEntities();

            if (orders != null) {
                foreach (var cart in orders) {
                    var oldCart = db.Cart.Find(cart.Id);
                    oldCart.DatePurchased = DateTime.Now;
                    oldCart.IsInCart = false;
                }

                db.SaveChanges();
            }
        }
    }
}