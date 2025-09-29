using UnityEngine;
using UnityEngine.SceneManagement;

public class AracnophobiaLevelManager : MonoBehaviour
{
    public void LoadAracnophobiaLevel1()
    {
        SceneManager.LoadScene("Aracnofobia Level 1");
    }

    public void BackButton2()
    {
        SceneManager.LoadScene("SelectPhobia");
    }
}
