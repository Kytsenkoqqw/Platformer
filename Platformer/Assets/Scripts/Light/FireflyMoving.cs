using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class FireflyMoving : MonoBehaviour
{
   [SerializeField] private Transform _target;

   private void Start()
   {
      StartCoroutine(StartMove());
   }


   private IEnumerator StartMove()
   {
      yield return new WaitForSeconds(2f);
      
      transform.DOMove(_target.position, 8).SetEase(Ease.OutSine);

   }
}
