using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic; 
using System;

[System.Serializable]
public class DialogueLine
{
    public string speakerName;
    [TextArea(2, 5)]
    public string text;
    public Sprite portrait;
}

public class VRDialogueManager : MonoBehaviour
{
    public Action onDialogueComplete;

    public Image portraitImage;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public TMP_Text hintText;
    public GameObject dialoguePanel;
    public float typingSpeed = 0.03f;

    private Queue<DialogueLine> dialogueQueue = new Queue<DialogueLine>();
    private bool isTyping = false;
    private bool dialogueActive = false;
    private string currentFullSentence = "";

    void Start()
    {
        dialoguePanel.SetActive(true);
    }

    void Update()
    {
        if (!dialogueActive) return;

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = currentFullSentence;
                isTyping = false;
                hintText.text = "R-Trigger →";
            }
            else
            {
                DisplayNextLine();
            }
        }
    }

    public void StartDialogue(DialogueLine[] lines)
    {
        dialogueQueue.Clear();
        foreach (var line in lines)
            dialogueQueue.Enqueue(line);

        dialogueActive = true;
        if (dialoguePanel != null) dialoguePanel.SetActive(true);
        DisplayNextLine();
    }
    public void DisplayNextLine()
    {
        if (isTyping) return;

        if (dialogueQueue.Count == 0)
        {
            dialogueActive = false;
            if (dialoguePanel != null) dialoguePanel.SetActive(false);
            onDialogueComplete?.Invoke(); 
            return;
        }

        DialogueLine currentLine = dialogueQueue.Dequeue();
        if (portraitImage != null) portraitImage.sprite = currentLine.portrait;
        if (nameText != null) nameText.text = currentLine.speakerName;

        currentFullSentence = currentLine.text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine.text));
    }   

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        if (dialogueText != null) dialogueText.text = "";
        if (hintText != null) hintText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            if (dialogueText != null) dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed); 
        }

        isTyping = false;
        if (hintText != null) hintText.text = "R-Trigger →";
    }
}
