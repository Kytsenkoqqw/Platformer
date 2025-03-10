using System;
using UnityEngine;

namespace Light
{
    public class LightFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private void LateUpdate()
        {
            transform.position = _target.position;
        }
    }
}