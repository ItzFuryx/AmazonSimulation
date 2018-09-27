using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Newtonsoft.Json;

namespace Controllers
{

    public abstract class Command
    {

        private string type;
        private Object parameters;

        public Command (string type, Object parameters)
        {
            this.type = type;
            this.parameters = parameters;
        }

        public string ToJson ()
        {
            return JsonConvert.SerializeObject (new
            {
                command = type,
                    parameters = parameters
            });
        }
    }

    public abstract class Model3DCommand : Command
    {

        public Model3DCommand (string type, Cart parameters) : base (type, parameters) { }
        public Model3DCommand (string type, ItemStand parameters) : base (type, parameters) { }
        public Model3DCommand (string type, Item parameters) : base (type, parameters) { }
    }

    public class UpdateModel3DCommand : Model3DCommand
    {

        public UpdateModel3DCommand (Cart parameters) : base ("update", parameters) { } 
        public UpdateModel3DCommand (ItemStand parameters) : base ("update", parameters) { }
        public UpdateModel3DCommand (Item parameters) : base ("update", parameters) { }
    }
}