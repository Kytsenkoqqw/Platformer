using System;
using System.Collections;
using ObjectBehaviour;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    private IMovement _movement;
    private IJumpable _jump;
    private IAttackable _attack;
    private IRotatable _rotation;

    private void Start()
    {
        _movement = GetComponent<IMovement>();
        _jump = GetComponent<IJumpable>();
        _attack = GetComponent<IAttackable>();
        _rotation = GetComponent<IRotatable>();
        
    }
    
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        // Взаимодействие с системами через интерфейсы
        _movement.Move();
        _attack.Attack();
        _jump.Jump();
        _rotation.ObjectRotate(horizontal);
    }
}