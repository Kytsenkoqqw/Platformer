using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 _offset = new Vector3(0,0.30f,-15);

    private void LateUpdate()
    {
        transform.position = _target.position + _offset;
    }
}
