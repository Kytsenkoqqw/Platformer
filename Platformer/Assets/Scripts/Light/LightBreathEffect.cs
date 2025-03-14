using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Light
{
    public class LightBreathEffect : MonoBehaviour
    {
        [SerializeField] private Light2D _light;
        private float _maxRadius = 1f;
        private float _minRadius = 0.7f;

        [SerializeField] private float _speedBreath;
        
        private void Start()
        {
            StartCoroutine(PulseLight());
        }
        
        private IEnumerator PulseLight()
        {
            float time = 0f;

            while (true) // Бесконечный цикл для пульсации
            {
                time += Time.deltaTime * _speedBreath;
                float radius = Mathf.Lerp(_minRadius, _maxRadius, Mathf.PingPong(time, 1f)); // Линейная интерполяция для плавного перехода
                _light.pointLightOuterRadius = radius;

                yield return null; // Ждем следующий кадр
            }
        }
    }
}