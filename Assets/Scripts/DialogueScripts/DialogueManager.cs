using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    
    [Header("UI References")]
    public Canvas dialogueCanvas;
    public TMP_Text actorName;
    public TMP_Text dialogueText;
    
    public bool isDialogueActive;
    
    private DialogueSO _currentDialogue;
    private int _dialogueIndex;

    private void Start()
    {
        ShowDialogue();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        dialogueCanvas.enabled = false;
    }

    public void StartDialogue(DialogueSO dialogue)
    {
        _currentDialogue = dialogue;
        _dialogueIndex = 0;
        isDialogueActive = true;
        
        ShowDialogue();
    }

    public void AdvanceDialogue()
    {
        if (_dialogueIndex < _currentDialogue.lines.Length)
        {
            ShowDialogue();
        }
        else
        {
            EndDialogue();
        }
    }
    
    private void ShowDialogue()
    {
        DialogueLine line = _currentDialogue.lines[_dialogueIndex];

        actorName.text = line.speaker.actorName;
        dialogueText.text = line.text;
        dialogueCanvas.enabled = true;
        
        _dialogueIndex++;
    }

    private void EndDialogue()
    {
        _dialogueIndex = 0;
        isDialogueActive = false;
        dialogueCanvas.enabled = false;
    }
}
