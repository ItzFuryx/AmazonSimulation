using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Models
{
    public class Model 
    {
        protected Vector3 _position = new Vector3 ();
        protected Quaternion _rotation = new Quaternion ();
        public Vector3 position { get { return _position; } }
        public Quaternion rotation { get { return _rotation; } }
    }
}