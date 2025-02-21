using System;
using ObjectBehaviour;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour, IRotateObject
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _jumpForce = 5f;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    
    private bool _isJumping;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal, 0, 0) * _moveSpeed * Time.deltaTime;

        _animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Jump();
        ObjectRotate(horizontal);

        // Проверяем, находится ли персонаж в воздухе
        if (!_isJumping && IsGrounded())
        {
            _animator.SetBool("IsJump", false);
            //_animator.SetBool("IsFall", false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _isJumping = true;
            _animator.SetBool("IsJump", true);
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce); // Импульсный прыжок
        }
    }

    private void FixedUpdate()
    {
        if (_isJumping)
        {
            if (_rigidbody.linearVelocity.y < 0) // Когда персонаж начинает падать
            {
                _animator.SetBool("IsJump", false);
                _animator.SetBool("IsFall", true);
            }

            if (IsGrounded()) // Если приземлился
            {
                _isJumping = false;
//                _animator.SetBool("IsFall", false);
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    public void ObjectRotate(float direction)
    {
        if (direction < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}