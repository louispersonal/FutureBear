using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputTextInteractable : Interactable
{
    [SerializeField]
    TMP_InputField _inputField;

    // Start is called before the first frame update
    void Start()
    {

    }

    protected override void Interact()
    {
        base.Interact();
    }

    protected override void UnInteract()
    {
        base.UnInteract();
    }
}
