using System;
using ObjectBehaviour;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour, IRotateObject
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed = 3f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal, 0,0 ) * _moveSpeed * Time.deltaTime;

        _animator.SetFloat("Speed", Mathf.Abs(horizontal));

        ObjectRotate(horizontal);
    }

    public void ObjectRotate(float direction)
    {
        if (direction <= -0.01)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale = new Vector3(1,1,1);
        }
    }
}
