using System;
using ObjectBehaviour;
using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour, IMovement
    {
        [SerializeField] private float _moveSpeed;
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.position += new Vector3(horizontal, 0,0) * _moveSpeed * Time.deltaTime;

            _animator.SetFloat("Speed", Mathf.Abs(horizontal));

        }

        public void Sprint()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _animator.SetBool("IsSprint", true);
                _moveSpeed = 2;
            }
            else
            {
                _animator.SetBool("IsSprint", false);
                _moveSpeed = 1f;
            }
        }
    }
}