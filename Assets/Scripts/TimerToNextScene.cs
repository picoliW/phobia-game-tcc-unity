using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerToNextScene : MonoBehaviour
{
    public float countdownTime = 30f;
    public TextMeshProUGUI timerText;
    public string nextSceneName;

    private float currentTime;

    void Start()
    {
        currentTime = countdownTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0, countdownTime);

        timerText.text = "Tempo restante: " + Mathf.CeilToInt(currentTime) + "s";

        if (currentTime <= 0)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
