using ObjectBehaviour;
using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour, IMovement
    {
        [SerializeField] private float _moveSpeed;
        
        public void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.position += new Vector3(horizontal, 0,0) * _moveSpeed * Time.deltaTime;
        }
    }
}