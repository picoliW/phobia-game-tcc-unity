using UnityEngine;
using UnityEngine.SceneManagement;

public class NictofobiaLevelManager : MonoBehaviour
{
    public void LoadNictophobiaLevel1()
    {
        SceneManager.LoadScene("Nictofobia Level1");
    }
    public void BackButton()
    {
        SceneManager.LoadScene("SelectPhobia");
    }
}
