using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "Dialogue/NPC Dialogue")]
public class DialogueSO : ScriptableObject
{
    public DialogueLine[] lines;
}

[System.Serializable]
public class DialogueLine
{
    public ActorSO speaker;
    [TextArea(3, 7)] public string text;
}
