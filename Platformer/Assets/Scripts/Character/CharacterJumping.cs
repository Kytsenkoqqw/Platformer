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
        [SerializeField] private Joystick _joystick;


        private AnimationManager _animationManager;
        private Rigidbody2D _rigidbody;
        private bool _isJumping;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animationManager = GetComponent<AnimationManager>();
        }

        private void Update()
        {
            Jumping();
        }

        private void FixedUpdate()
        {
            if (IsGrounded() && _isJumping)
            {
                _isJumping = false;
                _animationManager.PlayJump(false);
            }
        }

        //MobileJump
        public void Jumping()
        {
            float vertical = _joystick.Vertical;

            // Проверяем, если джойстик тянут вверх достаточно сильно
            if (IsGrounded() && vertical >= 0.5f) // 0.5f - оптимальное значение
            {
                _isJumping = true;
                _animationManager.PlayJump(true);
                _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
            }
        }

        //WASD Jump
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