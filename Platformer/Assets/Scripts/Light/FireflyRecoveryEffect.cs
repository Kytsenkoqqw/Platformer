using System;
using System.Collections;
using System.Security.Cryptography;
using System.Timers;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Light
{
    public class FireflyRecoveryEffect : MonoBehaviour
    {
        public Action OnRecovery;
        [SerializeField] private Transform _characterTransform;
        [SerializeField] private Light2D _light;
        [SerializeField] private float _speed;
        [SerializeField] private float _intensitySpeed;


        private bool _isOnPlace;

        private void Update()
        {
            if (Vector3.Distance(transform.position, _characterTransform.position) <= 0.2f)
            {
                _isOnPlace = true;
                _light.pointLightOuterRadius = Mathf.Lerp(_light.pointLightOuterRadius, 10, Time.deltaTime * _speed);

                _light.intensity = Mathf.Lerp(_light.intensity, 500, Time.deltaTime * _intensitySpeed);
                OnRecovery?.Invoke();
                StartCoroutine(DestroyFirefly());
            }
        }

        IEnumerator DestroyFirefly()
        {
            if (_isOnPlace)
            {
                yield return  new WaitForSeconds(2f);
                Destroy(gameObject);
            }
        }
    }
}