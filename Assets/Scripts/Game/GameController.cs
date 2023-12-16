using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameController : MonoBehaviour
{
    private PopupPoolController _popupPoolController;
    public PopupPoolController PopupPoolController
    {
        get
        {
            if (_popupPoolController == null)
            {
                _popupPoolController = FindObjectOfType<PopupPoolController>();
            }
            return _popupPoolController;
        }
    }

    private UIController _uIController;

    public UIController UIController
    {
        get
        {
            if (_uIController == null)
            {
                _uIController = FindObjectOfType<UIController>();
            }
            return _uIController;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
