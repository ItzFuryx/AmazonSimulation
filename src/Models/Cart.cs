using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Models
{
    public class Cart : MoveableModel, IUpdatable
    {
        public string type { get; }
        public Guid guid { get; }

        public Cart (Vector3 pos, Quaternion rot)
        {
            this.type = "cart";
            this.guid = Guid.NewGuid ();

            this._position = pos;
            this._rotation = rot;
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