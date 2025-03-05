using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   [SerializeField] private AudioSource _ambientForest;

   [SerializeField] private GameObject _pauseMenu;
   [SerializeField] private GameObject _settingsMenu;
   [SerializeField] private GameObject _loseGameMenu;

   [SerializeField] private Toggle _vSync;
   [SerializeField] private Toggle _soundToggle;
   
   
   private void Start()
   {
      _ambientForest.Play();
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
