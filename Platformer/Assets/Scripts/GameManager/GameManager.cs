using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField] private AudioSource _ambientForest;

   private void Start()
   {
      _ambientForest.Play();
   }
}
