using System;
using ObjectBehaviour;
using UnityEngine;

namespace Character
{
    public class CharacterJumping : MonoBehaviour, IJumpable
    {
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundLayer;


        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce); // Прыжок
            }
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
        }
    }
}