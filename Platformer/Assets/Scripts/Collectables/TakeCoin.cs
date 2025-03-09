using System;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

namespace Collectables
{
    public class TakeCoin : MonoBehaviour
    {
        public static Action OnTakeCoin;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") )
            {
                OnTakeCoin?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}