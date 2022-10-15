using Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Interactables
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Cube : MonoBehaviour, ISpawnObject
    {
        private NavMeshAgent _agent;
    
        private float _speed;
        private Vector3 _destination;
        
        private const float _stopDistance = 0.25f;

        private void Update()
        {
            if (!_agent.isStopped && _agent.remainingDistance <= _stopDistance)
                Disable();
        }

        public void Init(float speed, Vector3 destination)
        {
            _speed = speed;
            _destination = destination;
            _agent = GetComponent<NavMeshAgent>();
        
            MoveToTargetPoint();
        }

        private void MoveToTargetPoint()
        {
            _agent.speed = _speed;
            _agent.destination = _destination;
        }

        private void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}