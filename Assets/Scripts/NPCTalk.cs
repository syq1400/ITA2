using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    //code is ready for animations
    private Rigidbody rb;
    private Animator anim;
    public Animator interactAnim;
    
    public DialogueSO  dialogue;
    
    /*
    private void Awake()
    {
        rb  = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        rb.linearVelocity = Vector2.zero;
        rb.isKinematic = true;
        anim.Play("Open");
    }

    private void OnDisable()
    {
        interactAnim.SetTrigger("Close");
        rb.isKinematic = false;
    }
    */

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DialogueManager.Instance.isDialogueActive)
                DialogueManager.Instance.AdvanceDialogue();
            else
            {
                DialogueManager.Instance.StartDialogue(dialogue);
            }
        }
    }
}
