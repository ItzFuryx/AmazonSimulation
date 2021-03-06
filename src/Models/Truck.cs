using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Models
{
    public class Truck : MoveableModel, IUpdatable
    {
        private Item _item;
        public string type { get; }
        public Guid guid { get; }

        public Truck (Vector3 pos, Quaternion rot, Item item)
        {
            this.type = "truck";
            this.guid = Guid.NewGuid ();

            this._position = pos;
            this._rotation = rot;
            this._item = item;
        }

        public virtual bool Update (int tick)
        {
            if (Vector3.Distance (_position, _targetPosition) > 1)
            {
                _moving = true;
                _position = Vector3.MoveTowards (_position, _targetPosition, _movespeed);
                needsUpdate = true;
            }
            else
            {
                _moving = false;
            }

            if (needsUpdate)
            {
                needsUpdate = false;
                return true;
            }
            return false;
        }
    }
}