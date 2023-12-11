using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayTextInteractable : Interactable
{
    [SerializeField]
    UIController.DisplayMode _displayMode;

    [TextArea]
    [SerializeField]
    string _text;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Interact()
    {
        base.Interact();

        _gameController.UIController.DisplayMessage(_displayMode, _text);
    }

    protected override void UnInteract()
    {
        base.UnInteract();

        _gameController.UIController.ClearMessages();
    }
}
