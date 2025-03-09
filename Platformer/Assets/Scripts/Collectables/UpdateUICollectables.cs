using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Collectables
{
    public class UpdateUICollectables : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinText;
        [SerializeField] private int _coinValue;
        [SerializeField] private CurrensyManager _currensyManager;


        private void Start()
        {
            _coinText.text = _currensyManager.CointValue.ToString();
        }

        private void UpdateUICoin()
        {
            _coinValue++;
            _coinText.text = _coinValue.ToString();
        }
        
    }
}

