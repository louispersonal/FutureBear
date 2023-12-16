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

    private string _currentCode;

    private string _inputPreview;

    private DoorTrigger _currentDoor;

    private void Start()
    {
        _inputPreview = "";
        UpdatePreviewText();
    }

    public void Activate(DoorTrigger door)
    {
        this.gameObject.SetActive(true);
        _currentDoor = door;
        _currentCode = door.Code;
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
        _inputPreview = "";
        UpdatePreviewText();
        _currentDoor = null;
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
            _currentDoor.Unlock();
        }
    }


    private bool CheckCode()
    {
        if (_inputPreview == _currentCode)
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
