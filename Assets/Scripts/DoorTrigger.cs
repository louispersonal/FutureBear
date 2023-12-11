using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : Interactable
{
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
    }

    public void Unlock()
    {
        this.transform.parent.gameObject.SetActive(false);
    }
}
