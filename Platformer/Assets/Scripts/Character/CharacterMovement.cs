using System;
using System.Timers;
using Animation;
using ObjectBehaviour;
using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour, IMovement
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private AudioSource _runSound;

        private AnimationManager _animationManager;

        private void Start()
        {
            _animationManager = GetComponent<AnimationManager>();
        }

        private void Update()
        {
            //MoveCharacter();
        }

        //move on Joystick 
        public void Move()
        {
            float horizontalMobile = _joystick.Horizontal;

            if (Mathf.Abs(horizontalMobile)> 0.1f )
            {
                transform.position += new Vector3(horizontalMobile, 0,0) * _moveSpeed * Time.deltaTime;

                _animationManager.PlayRun(horizontalMobile);
            }
            else
            {
                _animationManager.PlayRun(0);
            }
           
        }

        //Move on WASD
        public void MoveCharacter()
        {
            float horizontal = Input.GetAxis("Horizontal");

            if (Mathf.Abs(horizontal) > 0.1f)
            {
                transform.position += new Vector3(horizontal, 0,0) * _moveSpeed * Time.deltaTime;
                _animationManager.PlayRun(horizontal); 
            }
            else
            {
                _animationManager.PlayRun(0);
            }
        }

        public void Sprint()
        {
            bool isSprinting = Input.GetKey(KeyCode.LeftShift);

            if (isSprinting)
            {
                _moveSpeed = 2f;
                _animationManager.PlaySprint(true);
            }
            else
            {
                _animationManager.PlaySprint(false);
                _moveSpeed = 1f;
            }
        }

        public void MobileSprint()
        {
            _moveSpeed = 2f;
            _animationManager.PlaySprint(true);
        }
    }
}