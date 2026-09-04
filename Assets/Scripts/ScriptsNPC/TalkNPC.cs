using TMPro;
using UnityEngine;

public class TalkNPC : MonoBehaviour
{
    private Rigidbody2D _body;
    
    public DialogueSO dialogueSO;
    public TMP_Text dialoguePrompt;

    private void Awake()
    {
        dialoguePrompt.enabled = false;
        _body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        dialoguePrompt.enabled = true;
        _body.linearVelocity = Vector2.zero;
        _body.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnDisable()
    {
        dialoguePrompt.enabled = false; 
        _body.linearVelocity = Vector2.zero;
        _body.bodyType = RigidbodyType2D.Dynamic;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialoguePrompt.enabled = false;
            
            if (DialogueManager.Instance.isDialogueActive)
            {
                DialogueManager.Instance.AdvanceDialogue();
            }
            else
            {
                DialogueManager.Instance.StartDialogue(dialogueSO);
            }
        }
    }
}
