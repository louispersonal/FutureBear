using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupPoolController : MonoBehaviour
{
    [SerializeField]
    Popup _popupPrefab;

    private List<Popup> _popups = new List<Popup>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Popup DisplayPopup(Vector2 popupPosition, string popupText)
    {
        Popup popup = GetAvailablePopup();
        popup.transform.position = popupPosition;
        popup.ChangeDisplayText(popupText);
        popup.gameObject.SetActive(true);
        return popup;
    }

    public void DismissPopup(Popup popup)
    {
        popup.gameObject.SetActive(false);
    }

    private Popup GetAvailablePopup()
    {
        for (int i = 0; i < _popups.Count; i++)
        {
            if (!_popups[i].gameObject.activeInHierarchy)
            {
                return _popups[i];
            }
        }
        Popup newPopup = Instantiate(_popupPrefab, this.transform);
        _popups.Add(newPopup);
        return newPopup;
    }
}
