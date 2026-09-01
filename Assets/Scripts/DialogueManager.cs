using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }
    [Header("UI References")]
    public TMP_Text actorDialogue;
    
    public bool isDialogueActive;
    
    private DialogueSO _currentDialogue;
    private int _dialogueIndex;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    
    public void StartDialogue(DialogueSO dialogue)
    {
        _currentDialogue = dialogue;
        ShowDialogue();
    }

    public void AdvanceDialogue()
    {
        if (_dialogueIndex < _currentDialogue.lines.Length)
            ShowDialogue();
        else
        
            Destroy(gameObject);
        
    }
    
    private void ShowDialogue()
    {
        DialogueLine lines = _currentDialogue.lines[_dialogueIndex];

        actorDialogue.text = lines.text;
        
        _dialogueIndex++;
    }
}
