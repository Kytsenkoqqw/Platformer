using System;
using ObjectBehaviour;
using UnityEngine;

namespace Enemy
{
    public class CadaverMovement : MonoBehaviour, IRotatable
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Transform[] _waypoints;
        

        private int _currentWaypointsIndex = 0;
        private float _waitTime = 2f;
        private float _waitTimer;
        private bool _isWaiting;

        private Transform _targetWaypoint;
        private Vector3 _direction;
        

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (_isWaiting)
            {
                _waitTimer += Time.deltaTime;
                if (_waitTimer >= _waitTime)
                {
                    _isWaiting = false;
                    _waitTimer = 0;
                }
                
                return;

            }

            _targetWaypoint = _waypoints[_currentWaypointsIndex];
            transform.position = Vector3.MoveTowards(transform.position, _targetWaypoint.position, _moveSpeed * Time.deltaTime);

            _direction = (_targetWaypoint.position - transform.position).normalized;

            if (Vector3.Distance(transform.position, _targetWaypoint.position) < 0.1f)
            {
                _currentWaypointsIndex++;
                if (_currentWaypointsIndex >= _waypoints.Length)
                {
                   // transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, _moveSpeed * Time.deltaTime);
                    _currentWaypointsIndex = 0;
                }

                _isWaiting = true;
            }

        }

        public void ObjectRotate(float direction)
        {
            if (_direction.x > 0)
            {
                transform.localScale = new Vector3(1,1,1);
            }
            else if (_direction.x < 0)
            {
                transform.localScale = new Vector3(-1,1,1);
            }
        }
    }
}