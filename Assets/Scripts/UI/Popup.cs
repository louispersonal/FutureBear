using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Popup : MonoBehaviour
{
    private TMP_Text _popupText;

    private void Awake()
    {
        _popupText = GetComponentInChildren<TMP_Text>();
    }

    public void ChangeDisplayText(string newText)
    {
        _popupText.text = newText;
    }
}
