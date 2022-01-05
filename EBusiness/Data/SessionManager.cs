using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// A cart is a list containing tuples with the first item being the id
// of the product and the second item being the amount.
using Cart = System.Collections.Generic.List<System.Tuple<int, int>>;

namespace EBusiness.Data
{
    public static class SessionManager
    {
        private static void StoreObjectInSession<T>(ISession session, string key, T obj)
        {
            string jsonString = JsonConvert.SerializeObject(obj);
            session.SetString(key, jsonString);
        }
        public static Cart GetCart(ISession session)
        {
            string cartString = session.GetString("cart");

            // If the session was not instantiated, create an empty list
            if(cartString == null)
            {
                Cart cart = new Cart();
                StoreObjectInSession(session, "cart", cart);
                return cart;
            }

            return JsonConvert.DeserializeObject<Cart>(cartString);
        }

        public static void SetCart(ISession session, Cart cart)
        {
            StoreObjectInSession(session, "cart", cart);
        }
    }
}
