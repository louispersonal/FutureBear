using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameController : StateController
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

    private ProjectilePoolController _projectilePoolController;
    public ProjectilePoolController ProjectilePoolController
    {
        get
        {
            if (_projectilePoolController == null)
            {
                _projectilePoolController = FindObjectOfType<ProjectilePoolController>();
            }
            return _projectilePoolController;
        }
    }
}
