using System;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

namespace Collectables
{
    public class TakeCoin : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinText;
        [SerializeField] private int _coinValue;
        
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") )
            {
                _coinValue++;
                _coinText.text = _coinValue.ToString();
                Destroy(gameObject);
            }
        }
    }
}