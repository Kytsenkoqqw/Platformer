using UnityEngine;

namespace Animation
{
    public class AnimationManager : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void PlayRun(float speed)
        {
            _animator.SetFloat("Speed", Mathf.Abs(speed));
        }

        public void PlayJump(bool isJumping)
        {
            _animator.SetBool("IsJump", isJumping);
        }

        public void PlaySprint(bool isSprinting)
        {
            _animator.SetBool("IsSprint", isSprinting);
        }

        public void PlayAttack()
        {
            _animator.SetTrigger("Attack");
        }

        public void PlayDeath()
        {
            _animator.SetTrigger("Death");
        }
    }
}