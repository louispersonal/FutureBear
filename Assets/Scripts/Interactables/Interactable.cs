using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    string _triggerTag;

    protected GameController _gameController;

    private Popup _currentLinkedPopup;

    private bool _triggerActive = false;

    private bool _interactActive = false;

    protected virtual void Start()
    {
        if(GetComponent<BoxCollider2D>() == null)
        {
            Debug.LogError("No collider on interactable object");
        }

        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        CheckTrigger();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(_triggerTag))
        {
            Trigger();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(_triggerTag))
        {
            UnTrigger();
        }
    }

    private void CheckTrigger()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (_interactActive)
            {
                UnInteract();
            }
            else if (_triggerActive)
            {
                Interact();
            }
        }

        if (!_triggerActive && _interactActive)
        {
            UnInteract();
        }
    }

    // Trigger means that the trigger zone has a triggerable type in it
    protected virtual void Trigger()
    {
        _triggerActive = true;
        ShowInteractPrompt();
    }

    protected virtual void UnTrigger()
    {
        _triggerActive = false;
        HideInteractPrompt();
    }

    protected virtual void ShowInteractPrompt()
    {
        _currentLinkedPopup = _gameController.PopupPoolController.DisplayPopup(this.gameObject.transform.position, "E");
    }

    protected virtual void HideInteractPrompt()
    {
        _gameController.PopupPoolController.DismissPopup(_currentLinkedPopup);
    }

    // Interact means that a triggerable type in the trigger zone interacted
    protected virtual void Interact()
    {
        _interactActive = true;
    }

    protected virtual void UnInteract()
    {
        _interactActive = false;
    }

}
