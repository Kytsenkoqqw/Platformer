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
            MoveCharacter();
        }

        //move on Joystick 
        public void Move()
        {
            float horizontal = _joystick.Horizontal;
            transform.position += new Vector3(horizontal, 0,0) * _moveSpeed * Time.deltaTime;

            _animationManager.PlayRun(horizontal);
        }

        public void MoveCharacter()
        {
            float horizontal = Input.GetAxis("Horizontal");
            
            transform.position += new Vector3(horizontal, 0,0) * _moveSpeed * Time.deltaTime;
            _animationManager.PlayRun(horizontal);
        }

        public void Sprint()
        {
            bool isSprinting = Input.GetKey(KeyCode.LeftShift);
            _animationManager.PlaySprint(isSprinting);
        }
    }
}