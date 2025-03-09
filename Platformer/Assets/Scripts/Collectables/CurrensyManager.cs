using System;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

namespace Collectables
{
    public class CurrensyManager : MonoBehaviour
    {
        [SerializeField] private int _coinValue;

        public int CointValue => _coinValue;

        public void AddCoin(int coinValue)
        {
            if (coinValue > 0)
            {
                _coinValue += coinValue;
            }
            else
            {
                Debug.LogWarning("Невозможно добавить отрицательное количество монет.");
            }
        }
    }
}