
using System;
using NUnit.Framework;
using ObjectBehaviour;
using UnityEngine;

namespace Character
{
    public class CharacterJumping : MonoBehaviour, IJumpable
    {
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundLayer;

        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private bool _isJumping;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            if (IsGrounded() && _isJumping)
            {
                _isJumping = false;
                _animator.SetBool("IsJump", false);
            }
        }


        public void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                _isJumping = true;
                _animator.SetBool("IsJump", true);
                _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
            }
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
        }
    }
}