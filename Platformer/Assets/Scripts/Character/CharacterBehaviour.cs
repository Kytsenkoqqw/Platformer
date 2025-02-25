using System;
using System.Collections;
using ObjectBehaviour;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour, IRotateObject
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private HealthSystem _healthSystem;
    
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _jumpForce = 5f;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private PolygonCollider2D _attackArea;
    
    
    private bool _isJumping;
    private bool _isDeath;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _healthSystem = GetComponent<HealthSystem>();

        _healthSystem.OnDeath += Die;
        _isDeath = false;
    }
    
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal, 0, 0) * _moveSpeed * Time.deltaTime;

        _animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Sprint();
        Jump();
        Attack();
        ObjectRotate(horizontal);
        
        if (!_isJumping && IsGrounded())
        {
            _animator.SetBool("IsJump", false);
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Attack");
            StartCoroutine(AttackDelay());
        }
    }

    private IEnumerator AttackDelay()
    {
        _attackArea.enabled = true;
        yield return new WaitForSeconds(1f);
        _attackArea.enabled = false;
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

    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _moveSpeed = 2;
            _animator.SetBool("IsSprint", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _animator.SetBool("IsSprint", false);
            _moveSpeed = 1;
        }
    }

    private void FixedUpdate()
    {
        if (_isJumping)
        {
            if (_rigidbody.linearVelocity.y < 0) 
            {
                _animator.SetBool("IsJump", false);
                _animator.SetBool("IsFall", true);
            }

            if (IsGrounded()) 
            {
                _isJumping = false;
            }
        }
    }

    private void OnDestroy()
    {
        _healthSystem.OnDeath -= Die;
    }

    private void Die()
    {
        _isDeath = true;

        if (_isDeath)
        {
            _animator.SetTrigger("Death");
            this.enabled = false;
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