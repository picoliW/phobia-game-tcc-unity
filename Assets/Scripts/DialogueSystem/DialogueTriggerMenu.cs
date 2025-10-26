using UnityEngine;

public class DialogueTriggerMenu : MonoBehaviour
{
    public VRDialogueManager dialogueManager;
    public string speakerName;
    public DialogueEntry[] dialogues;
    private const string DialogueShownKey = "MenuDialogueShown"; 

    void Start()
    {
        if (PlayerPrefs.GetInt(DialogueShownKey, 0) == 1)
        {
            if (dialogueManager != null)
            {
                dialogueManager.HideDialoguePanel();
            }
            return;
        }

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

        PlayerPrefs.SetInt(DialogueShownKey, 1);
        PlayerPrefs.Save();
    }
}