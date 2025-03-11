
using System;
using Animation;
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


        private AnimationManager _animationManager;
        private Rigidbody2D _rigidbody;
        private bool _isJumping;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (IsGrounded() && _isJumping)
            {
                _isJumping = false;
                _animationManager.PlayJump(false);
            }
        }

        public void Jumping()
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
        }


        public void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                _isJumping = true;
                _animationManager.PlayJump(true);

                _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
            }
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
        }
    }
}