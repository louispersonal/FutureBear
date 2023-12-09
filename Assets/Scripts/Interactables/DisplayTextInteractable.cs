using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayTextInteractable : Interactable
{
    [SerializeField]
    GameObject _textObject;

    [SerializeField]
    string _text;

    private void Start()
    {
        if( _textObject.GetComponentInChildren<TMP_Text>() == null)
        {
            Debug.LogError("No text on display text object");
        }
    }

    protected override void Interact()
    {
        base.Interact();

        _textObject.SetActive(true);
        _textObject.GetComponentInChildren<TMP_Text>().text = _text;
    }

    protected override void UnInteract()
    {
        base.UnInteract();

        _textObject.SetActive(false);
    }
}
