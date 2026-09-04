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
    
    public TMP_Text dialoguePrompt;
    public bool isDialogueActive;
    
    private DialogueSO _currentDialogue;
    private int _dialogueIndex;
    private int _saveMoveSpeed;

    private void Start()
    {
        _saveMoveSpeed = StatsManager.Instance.moveSpeed;
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
        dialoguePrompt.enabled = false;
        
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
            StatsManager.Instance.moveSpeed = _saveMoveSpeed;
        }
    }
    
    private void ShowDialogue()
    {
        DialogueLine line = _currentDialogue.lines[_dialogueIndex];
        
        actorName.text = line.speaker.actorName;
        dialogueText.text = line.text;
        dialogueCanvas.enabled = true;
        StatsManager.Instance.moveSpeed = 0;
        
        _dialogueIndex++;
    }

    private void EndDialogue()
    {
        _dialogueIndex = 0;
        isDialogueActive = false;
        dialogueCanvas.enabled = false;
        dialoguePrompt.enabled = true;
    }
}
