using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   [SerializeField] private AudioSource _ambientForest;

   [SerializeField] private GameObject _pauseMenu;
   [SerializeField] private GameObject _settingsMenu;

   [SerializeField] private Toggle _vSync;
   
   private void Start()
   {
      _ambientForest.Play();
   }

   public void Resume()
   {
      _pauseMenu.SetActive(false);
   }

   public void CloseSettingsPanel()
   {
      _settingsMenu.SetActive(false);
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
   }

   public void ExitGame()
   {
      Application.Quit();
   }
}
