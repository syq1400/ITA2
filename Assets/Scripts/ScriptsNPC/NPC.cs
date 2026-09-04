using UnityEngine;

public class NPC : MonoBehaviour
{
    public enum NPCState {Default, Idle, Patrol, Wander, Talk}
    public NPCState currentState = NPCState.Idle;
    

    public PatrolNPC patrol;
    public WanderNPC wander;
    public TalkNPC talk;
    
    private NPCState _defaultState;

    void Start()
    {
        _defaultState = currentState;
        SwitchState(currentState);
    }


    public void SwitchState(NPCState newState)
    {
        currentState = newState;
        
        patrol.enabled = newState == NPCState.Patrol;
        wander.enabled = newState == NPCState.Wander;
        talk.enabled = newState == NPCState.Talk;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SwitchState(NPCState.Talk);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SwitchState(_defaultState);
        }
    }
}
