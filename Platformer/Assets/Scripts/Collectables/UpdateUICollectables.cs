using System;
using TMPro;
using UnityEngine;

namespace Collectables
{
    public class UpdateUICollectables : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinText;
        [SerializeField] private int _coinValue;

        private void Start()
        {
            TakeCoin.OnTakeCoin += UpdateUICoin;
        }

        private void UpdateUICoin()
        {
            _coinValue++;
            _coinText.text = _coinValue.ToString();
        }

        private void OnDestroy()
        {
            TakeCoin.OnTakeCoin -= UpdateUICoin;
        }
    }
}