using Interfaces;
using Services;
using UnityEngine;
using UnityEngine.AI;

namespace Interactables
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Cube : MonoBehaviour, IUpdatable, ISpawnObject
    {
        private NavMeshAgent _agent;
    
        private float _speed;
        private Vector3 _destination;

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
            _agent.isStopped = false;
        }

        private void Disable()
        {
            _agent.isStopped = true;
            gameObject.SetActive(false);
        }

        public void Tick()
        {
            Debug.Log(_agent.pathPending);
            
            if (_agent.pathPending && _agent.remainingDistance == 0)
                Disable();
        }
    }
}