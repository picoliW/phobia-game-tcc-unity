using UnityEngine;
using TMPro;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public VRDialogueManager dialogueManager;
    public DialogueTriggerLevel dialogueTrigger;
    public TMP_Text countdownText;
    public GameObject player; 

    private bool dialogueFinished = false;

    void Start()
    {
        Time.timeScale = 0f;

        dialogueManager.onDialogueComplete = OnDialogueFinished;
        
    }

    void OnDialogueFinished()
    {
        dialogueFinished = true;
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        countdownText.gameObject.SetActive(true);

        for (int i = 5; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }

        yield return new WaitForSecondsRealtime(1f);
        countdownText.gameObject.SetActive(false);

        Time.timeScale = 1f;
    }
}
