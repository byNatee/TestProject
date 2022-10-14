using Interfaces;
using UnityEngine;

namespace Interactables
{
    public class ObjectSpawner : MonoBehaviour, IUpdatable
    {
        [SerializeField] private ObjectsPool _pool;
        private float _timer;
    
        public float spawnTime;
        public float spawnObjectSpeed;
        public Vector3 spawnObjectDistance;

        private void Start()
        {
            _timer = spawnTime;
            Spawn();
        }

        private void Spawn()
        {
            var newSpawnObject = _pool.GetFreeObject();
            newSpawnObject.transform.position = Vector3.zero;
        
            var spawnObjectComponent = newSpawnObject.GetComponent<ISpawnObject>();

            if (spawnObjectComponent != null)
                spawnObjectComponent.Init(spawnObjectSpeed, spawnObjectDistance);
            else
                newSpawnObject.SetActive(false);
        }

        public void Tick()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                Spawn();
                _timer = spawnTime;
            }
        }
    }
}