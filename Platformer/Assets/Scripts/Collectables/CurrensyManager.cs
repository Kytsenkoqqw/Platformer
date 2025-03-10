using System;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

namespace Collectables
{
    public class CurrensyManager : MonoBehaviour
    {
        public static CurrensyManager instance;
        public Action OnChangeValueCoin;
        [SerializeField] private int _coinValue;

        public int CoinValue => _coinValue;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        
        public void AddCoin(int coinValue)
        {
            if (coinValue > 0)
            {
                _coinValue += coinValue;
                OnChangeValueCoin?.Invoke();
            }
            else
            {
                Debug.LogWarning("Невозможно добавить отрицательное количество монет.");
            }
        }
    }
}