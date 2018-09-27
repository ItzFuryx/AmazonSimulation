using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Models
{
    public class CartManager
    {
        private List<Cart> _carts = new List<Cart> ();
        public List<Cart> carts { get { return _carts; } }
        private Vector3 spawnpos = new Vector3();
        public Cart CreateCart (Vector3 pos)
        {
            Cart c = new Cart (pos, new Quaternion (0, 0, 0));            
            _carts.Add (c);
            return c;
        }

        public void SendCart (Vector3 pos)
        {
            foreach (Cart c in _carts)
            {
                
                if (!c.moving)
                {
                    c.Move (pos);
                    return;
                }
            }

            Cart cart = CreateCart(spawnpos);
            cart.Move(pos);
        }
    }
}