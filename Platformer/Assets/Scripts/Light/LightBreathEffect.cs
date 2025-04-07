using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Light
{
    public class LightBreathEffect : MonoBehaviour
    {
        [SerializeField] private FireflyRecoveryEffect _recovery;
        [SerializeField] private AudioSource _breathSound;
        
        [SerializeField] private Light2D _light;
        private float _maxRadius = 1f;
        private float _minRadius = 0.7f;

        [SerializeField] private float _speedBreath;
        private bool _isBreathEffect;
        
        private void Start()
        {
            _breathSound.Play();
            _recovery.OnRecovery += OffBreathEffect;
            _isBreathEffect = true;
            StartCoroutine(PulseLight());
        }
        

        private void OnDisable()
        {
            _recovery.OnRecovery -= OffBreathEffect;
        }

        private IEnumerator PulseLight()
        {
            if (_isBreathEffect)
            {
                float time = 0f;

                while (true) // Бесконечный цикл для пульсации
                {
                    time += Time.deltaTime * _speedBreath;
                    float radius = Mathf.Lerp(_minRadius, _maxRadius, Mathf.PingPong(time, 1f)); // Линейная интерполяция для плавного перехода
                    _light.pointLightOuterRadius = radius;

                    yield return null;

                    if (_isBreathEffect == false)
                    {
                        _light.pointLightOuterRadius = 10;
                        StartCoroutine(FadeOutBreathSound(2f));
                        yield break;
                    }
                }
            }
        }
        
        private IEnumerator FadeOutBreathSound(float duration)
        {
            float startVolume = _breathSound.volume;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                _breathSound.volume = Mathf.Lerp(startVolume, 0f, elapsed / duration);
                yield return null;
            }

            _breathSound.volume = 0f;
        }
        
        private void OffBreathEffect()
        {
            _isBreathEffect = false;
        }
        
    }
}