using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public int ButtonValue;

    [SerializeField]
    TMP_Text _buttonText;

    private DoorCode _doorCode;

    private GraphicRaycaster _raycaster;

    private void Start()
    {
        _raycaster = GetComponentInParent<GraphicRaycaster>();

        _doorCode = GetComponentInParent<DoorCode>();

        _buttonText.text = ButtonValue.ToString();
        if (ButtonValue < 0)
        {
            _buttonText.text = "C";
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            List<RaycastResult> results = new List<RaycastResult>();

            pointerData.position = Input.mousePosition;
            _raycaster.Raycast(pointerData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject == this.gameObject)
                {
                    _doorCode.RegisterButtonPress(ButtonValue);
                }
            }
        }
    }
}
