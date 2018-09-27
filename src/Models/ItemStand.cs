using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Models
{
    public class ItemStand : IUpdatable
    {
        private Item _item;
        public string type { get; }
        public Guid guid { get; }
        protected Vector3 _position = new Vector3 ();
        protected Quaternion _rotation = new Quaternion ();
        public Vector3 position { get { return _position; } }
        public Quaternion rotation { get { return _rotation; } }

        public bool needsUpdate = true;
        public ItemStand (Vector3 pos, Quaternion rot, Item item)
        {
            this.type = "itemStand";
            this.guid = Guid.NewGuid ();

            this._position = pos;
            this._rotation = rot;
            this._item = item;
        }

        public virtual bool Update (int tick)
        {
            if (needsUpdate)
            {
                needsUpdate = false;
                return true;
            }
            return false;
        }
    }
}