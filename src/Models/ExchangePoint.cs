using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Models
{
    public class ExchangePoint : Model
    {
        public string type { get; }
        public Guid guid { get; }
        public float cash = 1000;
        private List<Item> _dynamite = new List<Item> ();
        private List<Item> _ores = new List<Item> ();

        public ExchangePoint ()
        {
            this.type = "exchangepoint";
            this.guid = Guid.NewGuid ();
            position.x = 15;
            position.z = 0;
        }

        public void OnReceiveItem (Item item)
        {
            if (item.itemType == ItemType.Dynamite)
            {
                _dynamite.Add (item);
                cash -= 5;
            }
            else
            {
                _ores.Add (item);
            }
        }
        public Item OnSendItem (ItemType type)
        {
            Item itemToSend;
            if (type == ItemType.Dynamite)
            {
                itemToSend = _dynamite[0];
                _dynamite.Remove (itemToSend);
            }
            else
            {
                itemToSend = _ores[0];
                _ores.Remove (itemToSend);
                cash += 10;
            }
            return itemToSend;
        }
    }
}