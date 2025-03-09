using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

namespace Collectables
{
    public class TakeCoin : MonoBehaviour
    {
        [SerializeField] private CurrensyManager _currensyManager;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _currensyManager.AddCoin(5);
                Destroy(gameObject);
            }
        }
    }
}