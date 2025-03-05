using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class VampireBatChasing : MonoBehaviour
    {
        [SerializeField] private float _detectionRadius = 1.5f;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Transform _characterTransform;


        private void Update()
        {
            FindCharacter();
        }


        private void FindCharacter()
        {
            Collider2D colliders = Physics2D.OverlapCircle(transform.position, _detectionRadius, LayerMask.GetMask("Character"));
            if (colliders != null)
            {
                MoveToCharacter();
            }
        }

        private void MoveToCharacter()
        {
            transform.position = Vector2.MoveTowards(transform.position, _characterTransform.position, _moveSpeed * Time.deltaTime);
        }


    }
}