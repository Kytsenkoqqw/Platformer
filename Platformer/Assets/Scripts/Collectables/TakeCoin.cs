using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


namespace Collectables
{
    public class TakeCoin : MonoBehaviour
    {
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.CompareTag("Player"))
            {
                var randomNumber = Random.Range(1, 5);
                CurrensyManager.instance.AddCoin(randomNumber);
                Destroy(gameObject);
            }
        }
    }
}