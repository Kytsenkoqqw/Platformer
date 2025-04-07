using System;
using Animation;
using DG.Tweening;
using Light;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

   [SerializeField] private FireflyRecoveryEffect _recoveryEffect;

   
   //AnimationManager
   [SerializeField] private AnimationManager _animationManager;
   
   
   //Sound
   [SerializeField] private AudioSource _ambientForest;

   //GameMenu
   [SerializeField] private GameObject _pauseMenu;
   [SerializeField] private GameObject _settingsMenu;
   [SerializeField] private GameObject _loseGameMenu;

   //Toggle
   [SerializeField] private Toggle _vSync;
   [SerializeField] private Toggle _soundToggle;

   //TransitionToLocation
   [SerializeField] private GameObject _transitionToLocationPanel;
  // [SerializeField] private TextMeshProUGUI _messageText;
   [SerializeField] private Transform _cameraTransform;
   
   //Character
   [SerializeField] private Sprite _charactercSprite;
   [SerializeField] private CircleCollider2D _characterCircleCollider2D;
   [SerializeField] private SpriteRenderer _spriteRenderer;
   
   
   private void Start()
   {
      _ambientForest.Play();
      _animationManager.OffAllAnimation();
      _recoveryEffect.OnRecovery += Recovery;
      Debug.Log(Application.persistentDataPath);
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.G))
      {
         _spriteRenderer.sprite = _charactercSprite;
      }
   }

   private void OnDestroy()
   {
      _recoveryEffect.OnRecovery -= Recovery;
   }

   private void Recovery()
   {
      _spriteRenderer.sprite = _charactercSprite;
      _characterCircleCollider2D.enabled = true;
      _animationManager.OnAllAnimation();
   }

   public void RestartGame()
   {
      SceneManager.LoadScene(0);
   }

   public void Resume()
   {
      _pauseMenu.SetActive(false);
   }

   public void CloseSettingsPanel()
   {
      _settingsMenu.SetActive(false);
   }

   public void ShowLoseMenu()
   {
      _loseGameMenu.SetActive(true);
   }

   public void ShowPauseMenu()
   {
      _pauseMenu.SetActive(true);
   }

   public void ShowSettingsMenu()
   {
      _pauseMenu.SetActive(false);
      _settingsMenu.SetActive(true);
   }

   public void StartTransitionToLocation()
   {
      _cameraTransform.transform.DOMove(new Vector3(9, 0.22f, -10), 2f);
      _transitionToLocationPanel.transform.DOScale(new Vector3(0, 0, 0), 1f);
      _transitionToLocationPanel.SetActive(false);
      
   }

   public void CloseTransitionPanel()
   {
      _transitionToLocationPanel.transform.DOScale(new Vector3(0, 0, 0), 1f);
      _transitionToLocationPanel.SetActive(false);
   }

   public void OnToggleValueChanged()
   { 
      if (_vSync.isOn)
      {
         Debug.Log("toggle is on ");
         QualitySettings.vSyncCount = 0;
         Application.targetFrameRate = 60;
      }
      else
      {
         Debug.Log("toggle is off");
         Application.targetFrameRate = -1;
      }

      if (EventSystem.current.currentSelectedGameObject == _soundToggle.gameObject)
      {
         if (_soundToggle.isOn)
         {
            Debug.Log("Ambient sound ON");
            if (!_ambientForest.isPlaying) // Чтобы не перезапускать
            {
               _ambientForest.Play();
            }
         }
         else
         {
            Debug.Log("Ambient sound OFF");
            _ambientForest.Stop();
         }
      }
   }

   public void ExitGame()
   {
      Application.Quit();
   }
}
