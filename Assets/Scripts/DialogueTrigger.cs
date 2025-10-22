using UnityEngine;

[System.Serializable]
public class DialogueEntry
{
    [TextArea(2, 5)]
    public string text;
    public Sprite portrait;
}

public class DialogueTrigger : MonoBehaviour
{
    public VRDialogueManager dialogueManager;
    public string speakerName;
    public DialogueEntry[] dialogues; 

    void Start()
    {
        DialogueLine[] lines = new DialogueLine[dialogues.Length];

        for (int i = 0; i < dialogues.Length; i++)
        {
            lines[i] = new DialogueLine
            {
                speakerName = speakerName,
                text = dialogues[i].text,
                portrait = dialogues[i].portrait
            };
        }

        dialogueManager.StartDialogue(lines);
    }
}
