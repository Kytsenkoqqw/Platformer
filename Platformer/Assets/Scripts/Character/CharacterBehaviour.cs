using System;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    private float _horizontal;
    

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(_horizontal, 0,0 ) * _moveSpeed * Time.deltaTime;
        
        RotateCharacter();
    }

    private void RotateCharacter()
    {
        if (_horizontal <= -0.01)
        {
            transform.localScale = new Vector3(-1,1,0);
        }
        else
        {
            transform.localScale = new Vector3(1,1,0);
        }
    }
}
