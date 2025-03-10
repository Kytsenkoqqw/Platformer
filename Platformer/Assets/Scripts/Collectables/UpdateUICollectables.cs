using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Collectables
{
    public class UpdateUICollectables : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinText;
        [SerializeField] private CurrensyManager _currensyManager;
        
        
        private void Start()
        {
            _coinText.text = _currensyManager.CoinValue.ToString();
            _currensyManager.OnChangeValueCoin += UpdateUICoin;
        }

        private void UpdateUICoin()
        {
            Debug.Log($"Обновляем UI: {_currensyManager.CoinValue}");
            _coinText.text = _currensyManager.CoinValue.ToString();
        }

        private void OnDestroy()
        {
            _currensyManager.OnChangeValueCoin -= UpdateUICoin;
        }
    }
}

