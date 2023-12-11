using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorCode : MonoBehaviour
{
    [SerializeField]
    List<Button> buttons;

    [SerializeField]
    TMP_Text _textBox;

    [SerializeField]
    string code;

    private string _inputPreview;

    private void Start()
    {
        _inputPreview = "";
        UpdatePreviewText();
    }

    public void RegisterButtonPress(int input)
    {
        if (input < 0)
        {
            _inputPreview = "";
        }

        else
        {
            _inputPreview += input.ToString();
        }

        UpdatePreviewText();

        if (CheckCode())
        {
            Debug.Log("Door opened!");
        }
    }


    private bool CheckCode()
    {
        if (_inputPreview == code)
        {
            return true;
        }
        return false;
    }

    private void UpdatePreviewText()
    {
        _textBox.text = _inputPreview;
    }
}
