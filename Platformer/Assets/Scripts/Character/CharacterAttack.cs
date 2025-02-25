using System;
using ObjectBehaviour;
using UnityEngine;

namespace Character
{
    public class CharacterAttack : MonoBehaviour, IAttackable
    {
        public void Attack()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Attack");
            }
        }
    }
}