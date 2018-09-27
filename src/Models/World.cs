using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;

namespace Models
{
    public class World : IObservable<Command>, IUpdatable
    {
        private List<IObserver<Command>> observers = new List<IObserver<Command>> ();
        private CartManager manager = new CartManager ();
        private ExchangePoint exchanger = new ExchangePoint ();
        private List<ItemStand> itemStands = new List<ItemStand> ();

        public World () // init world
        {
            manager.CreateCart (new Vector3 (0, 0, 0));
            for (var i = 0; i < 6; i++)
            {
                itemStands.Add(new ItemStand(new Vector3(7.5f, 1.1f, 5 + i *4), new Quaternion(), new Item()));
                itemStands.Add(new ItemStand(new Vector3(22.5f, 1.1f, 5 + i *4), new Quaternion(), new Item()));
            }

            /*
            manager.SendCart (new Vector3 (5, 0, -20));
            manager.SendCart (new Vector3 (25, 0, -20));
            manager.SendCart (new Vector3 (10, 0, -20));
            manager.SendCart (new Vector3 (-5, 0, -20));
            manager.SendCart (new Vector3 (-25, 0, -20));
            manager.SendCart (new Vector3 (-10, 0, -20));
            */
        }

        public IDisposable Subscribe (IObserver<Command> observer)
        {
            if (!observers.Contains (observer))
            {
                observers.Add (observer);

                SendCreationCommandsToObserver (observer);
            }
            return new Unsubscriber<Command> (observers, observer);
        }

        private void SendCommandToObservers (Command c)
        {
            for (int i = 0; i < this.observers.Count; i++)
            {
                this.observers[i].OnNext (c);
            }
        }

        private void SendCreationCommandsToObserver (IObserver<Command> obs)
        {
            foreach (Cart m3d in manager.carts)
            {
                obs.OnNext (new UpdateModel3DCommand (m3d));
            }
        }

        public bool Update (int tick)
        {
            for (int i = 0; i < itemStands.Count; i++)
            {
                ItemStand u = itemStands[i];
                if (u is IUpdatable)
                {
                    bool needsCommand = ((IUpdatable) u).Update (tick);

                    if (needsCommand)
                    {
                        SendCommandToObservers (new UpdateModel3DCommand (u));
                    }
                }
            }

            for (int i = 0; i < manager.carts.Count; i++)
            {
                Cart u = manager.carts[i];
                if (u is IUpdatable)
                {
                    bool needsCommand = ((IUpdatable) u).Update (tick);

                    if (needsCommand)
                    {
                        SendCommandToObservers (new UpdateModel3DCommand (u));
                    }
                }
            }

            return true;
        }
    }

    internal class Unsubscriber<Command> : IDisposable
    {
        private List<IObserver<Command>> _observers;
        private IObserver<Command> _observer;

        internal Unsubscriber (List<IObserver<Command>> observers, IObserver<Command> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose ()
        {
            if (_observers.Contains (_observer))
                _observers.Remove (_observer);
        }
    }
}