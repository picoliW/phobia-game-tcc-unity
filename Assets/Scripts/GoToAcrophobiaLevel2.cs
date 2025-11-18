using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoToAcrophobiaLevel2 : MonoBehaviour
{
    public GameObject avisoUI;
    private bool avisoAtivo = false;
    public GameObject canvasPrincipal;

    public void LoadAcrophobiaLevel2(int opcao)
    {
        if (opcao == 1 || opcao == 2)
        {
            SceneManager.LoadScene("AcrophobiaLevel2");
        }
        else if (opcao == 3 || opcao == 4)
        {
            canvasPrincipal.SetActive(false);
            if (!avisoAtivo)
            {
                avisoUI.SetActive(true);
                avisoAtivo = true;
            }
        }
        else if (opcao == 5)
        {
            StartCoroutine(MostrarAvisoEFechar());
        }
    }

    public void LoadAcrophobiaLevel2Button(){
        SceneManager.LoadScene("AcrophobiaLevel2");
    }

    private IEnumerator MostrarAvisoEFechar()
    {
        avisoUI.SetActive(true); 
        yield return new WaitForSeconds(5f);
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene("AcrophobiaLevel1");
    }
}
