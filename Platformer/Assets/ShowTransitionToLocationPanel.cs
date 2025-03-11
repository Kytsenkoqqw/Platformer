using System;
using DG.Tweening;
using UnityEngine;

public class ShowTransitionToLocationPanel : MonoBehaviour
{
    [SerializeField] private GameObject _transitionPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterBehaviour>())
        {
            _transitionPanel.SetActive(true);
            _transitionPanel.transform.DOScale(new Vector3(1, 1, 1), 1f);
        }
    }
}
