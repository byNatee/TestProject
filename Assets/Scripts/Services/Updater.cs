using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;

namespace Services
{
    public class Updater : MonoBehaviour, IUpdate
    {
        private List<IUpdatable> _updatables;

        private void Start()
        {
            _updatables = new List<IUpdatable>();
        }

        private void Update()
        {
            foreach (var updatable in _updatables.ToList())
            {
                if(updatable != null)
                    updatable.Tick();
            }
            
            Debug.Log("fsdfsd");
        }

        public void Attach(IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }

        public void Detach(IUpdatable updatable)
        {
            _updatables.Remove(updatable);
        }
    }
}
