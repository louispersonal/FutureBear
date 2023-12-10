using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject _computer;

    [SerializeField]
    GameObject _notepad;

    public enum DisplayMode
    {
        COMPUTER,
        NOTEPAD
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayMessage(DisplayMode mode, string message)
    {
        if (mode == DisplayMode.COMPUTER)
        {
            _computer.SetActive(true);
            _computer.GetComponentInChildren<TMP_Text>().text = message;
        }

        else if (mode == DisplayMode.NOTEPAD)
        {
            _notepad.SetActive(true);
            _notepad.GetComponentInChildren<TMP_Text>().text = message;
        }
    }

    public void ClearMessages()
    {
        _computer.SetActive(false);
        _notepad.SetActive(false);
    }
}
