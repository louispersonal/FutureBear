using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : Interactable
{
    [SerializeField]
    string _code;

    public string Code
    {
        get { return _code; }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Interact()
    {
        base.Interact();

        _gameController.UIController.TryDoor(this);
    }

    protected override void UnInteract()
    {
        base.UnInteract();

        _gameController.UIController.CancelDoor();
    }

    public void Unlock()
    {
        this.transform.parent.gameObject.SetActive(false);

        UnInteract();
    }
}
