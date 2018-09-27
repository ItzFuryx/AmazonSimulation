using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Models
{
    public class Moveable
    {
        protected bool _moving = false;
        protected Vector3 _targetPosition = new Vector3 ();
        protected Vector3 _position = new Vector3 ();
        protected Quaternion _rotation = new Quaternion ();
        protected float _movespeed = 0.1f;

        public bool moving { get { return _moving; } }
        public Vector3 position { get { return _position; } }
        public Quaternion rotation { get { return _rotation; } }
        public float movespeed { get { return _movespeed; } }

        public bool needsUpdate = true;

        
        public virtual void Move (Vector3 pos)
        {
            _moving = true;
            this._targetPosition = pos;
        }

        public virtual void Rotate (Quaternion rot)
        {
            this._rotation = rot;

            needsUpdate = true;
        }
    }
}