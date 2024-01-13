using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject _computer;

    [SerializeField]
    GameObject _scrapPaper;

    [SerializeField]
    DoorCode _doorCode;

    [SerializeField]
    GameObject _notepad;

    private bool _usingNotepad = true;
    private PlayerController _playerController;

    public enum DisplayMode
    {
        COMPUTER,
        SCRAP_PAPER
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Notepad"))
        {
            if (_usingNotepad && _playerController.CanOpenNotepad)
            {
                ExitNotepad();
            }
            else
            {
                AccessNotepad();
            }
        }
    }

    public void DisplayMessage(DisplayMode mode, string message)
    {
        if (mode == DisplayMode.COMPUTER)
        {
            _computer.SetActive(true);
            _computer.GetComponentInChildren<TMP_Text>().text = message;
        }

        else if (mode == DisplayMode.SCRAP_PAPER)
        {
            _scrapPaper.SetActive(true);
            _scrapPaper.GetComponentInChildren<TMP_Text>().text = message;
        }
    }

    public void ClearMessages()
    {
        _computer.SetActive(false);
        _scrapPaper.SetActive(false);
    }

    public void TryDoor(DoorTrigger door)
    {
        _doorCode.Activate(door);
    }

    public void CancelDoor()
    {
        _doorCode.Deactivate();
    }

    public void AccessNotepad()
    {
        _playerController.ForceIdle();
        _notepad.SetActive(true);
        _usingNotepad = true;
    }

    public void ExitNotepad()
    {
        _notepad.SetActive(false);
        _usingNotepad = false;
        _playerController.ForceResumeLastState();
    }
}
