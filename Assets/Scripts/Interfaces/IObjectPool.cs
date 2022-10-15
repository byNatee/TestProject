using UnityEngine;

namespace Interfaces
{
    public interface IObjectPool
    {
        public GameObject GetFreeObject();
    }
}