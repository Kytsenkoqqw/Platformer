using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   [SerializeField] private AudioSource _ambientForest;

   [SerializeField] private Button _resumeButton;
   [SerializeField] private Button _settingsButton;
   [SerializeField] private Button _exitButton;

   [SerializeField] private GameObject _pauseMenu;
   [SerializeField] private GameObject _settingsMenu;

   [SerializeField] private Toggle _vSync;
   
   
   
   
   private void Start()
   {
      _ambientForest.Play();
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

   public void OnToggleValueChanged(bool isOn)
   {
      if (isOn)
      {
         QualitySettings.vSyncCount = 0;
      }
      else
      {
         QualitySettings.vSyncCount = 1;
      }
   }
}
