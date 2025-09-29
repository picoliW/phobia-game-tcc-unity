using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPhobiaManager : MonoBehaviour
{
    public void LoadAracnophobiaLevels()
    {
        SceneManager.LoadScene("Select Aracnofobia Levels");
    }

    public void LoadAcrophobiaLevels()
    {
        SceneManager.LoadScene("Select Acrofobia Levels");
    }

    public void LoadNictophobiaLevels()
    {
        SceneManager.LoadScene("Select Nictofobia Levels");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
