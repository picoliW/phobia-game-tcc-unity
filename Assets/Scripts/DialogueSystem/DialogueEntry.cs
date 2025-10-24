using UnityEngine;

[System.Serializable]
public class DialogueEntry
{
    [TextArea(2, 5)]
    public string text;
    public Sprite portrait;
}
