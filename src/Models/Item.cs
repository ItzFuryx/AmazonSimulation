using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Models
{
    public enum ItemType{
        Ores,
        Dynamite
    }
    public class Item : IUpdatable
    {
        private ItemType _itemType;
        private Vector3 _position = new Vector3 ();
        private Quaternion _rotation = new Quaternion ();
        public string type { get; }
        public Guid guid { get; }
        public ItemType itemType { get { return _itemType; } }
        public Vector3 position { get { return _position; } }
        public Quaternion rotation { get { return _rotation; } }
        public bool needsUpdate = true;
        
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