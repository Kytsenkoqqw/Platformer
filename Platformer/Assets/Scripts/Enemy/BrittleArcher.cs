using System;
using UnityEngine;

public class BrittleArcher : MonoBehaviour
{
   [SerializeField] private HealthSystem _healthSystem;

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.GetComponent<CharacterBehaviour>())
      {
         _healthSystem.TakeDamage(10);
      }
   }
}
