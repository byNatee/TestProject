using Interfaces;
using UnityEngine;

namespace Interactables
{
    public class ObjectSpawner : MonoBehaviour
    {
        private IObjectPool _pool;
        
        private Vector3 _createdObjectDestination;
        private int _createdObjectSpeed;
        private int _spawnTime;
        private float _timer;

        private void Start()
        {
            InitFields();
        }

        private void InitFields()
        {
            _createdObjectDestination = Vector3.zero;
            _createdObjectSpeed = 0;
            _spawnTime = 0;
            _timer = 0;
        }

        private void Update()
        {
            if (_pool == null)
                return;
      
            _timer -= Time.deltaTime;

            if (_spawnTime != 0 && _timer <= 0)
            {
                Spawn();
                _timer = _spawnTime;
            }
        }

        private void Spawn()
        {
            var newSpawnObject = _pool.GetFreeObject();
            newSpawnObject.transform.position = Vector3.zero;
            newSpawnObject.transform.rotation = Quaternion.identity;
        
            var spawnObjectComponent = newSpawnObject.GetComponent<ISpawnObject>();

            if (spawnObjectComponent != null)
                spawnObjectComponent.Init(_createdObjectSpeed, _createdObjectDestination);
            else
                newSpawnObject.SetActive(false);
        }

        public void SetPool(IObjectPool pool)
        {
            _pool = pool;
        }

        public void OnFieldsChange(int speed, int spawnTime, Vector3 distance)
        {
            if (speed != 0)
                _createdObjectSpeed = speed;

            if (spawnTime != 0)
            {
                _spawnTime = spawnTime;
                _timer = 0;
            }
            
            if(distance.x != 0 || distance.z != 0)
                _createdObjectDestination = distance;
        }
    }
}