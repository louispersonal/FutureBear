using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputFieldGrabber : MonoBehaviour
{
    [Header("The value we got from the input field")]
    [SerializeField]
    private string _inputText;

    public void GrabFromInputField(string input)
    {
        _inputText = input;
    }
}
