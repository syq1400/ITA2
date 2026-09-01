using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu (fileName = "DialogueSO", menuName = "Dialogue System/Dialogue")]
public class DialogueSO : ScriptableObject
{
    public DialogueLine[]  lines;
}

[System.Serializable]
public class DialogueLine
{
    public NPCSO speaker;
    [TextArea(3,5)] public string text;
}
