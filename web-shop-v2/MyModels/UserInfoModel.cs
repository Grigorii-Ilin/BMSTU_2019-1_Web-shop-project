using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace web_shop_v2.MyModels {
    public class UserInfoModel {
        public UserInfo GetUserInfo(string guid) {
            var db = new VegetableDBEntities();
            var userInfo = (from x in db.UserInfo
                            where x.Guid == guid
                            select x).FirstOrDefault();

            return userInfo;
        }

        public void InsertUserInfo(UserInfo userInfo) {
            var db = new VegetableDBEntities();
            db.UserInfo.Add(userInfo);
            //https://stackoverflow.com/questions/21606454/how-to-handle-system-data-entity-validation-dbentityvalidationexception
            db.SaveChanges();

            //try {
            //    db.SaveChanges();
            //}
            //catch (DbEntityValidationException ex) {
            //    foreach (var entityValidationErrors in ex.EntityValidationErrors) {
            //        foreach (var validationError in entityValidationErrors.ValidationErrors){
            //            System.Diagnostics.Debug
            //                .WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        
            //        }
            //    }
            //}
        }
    }
}