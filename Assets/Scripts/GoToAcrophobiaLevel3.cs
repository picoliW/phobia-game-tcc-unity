using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoToAcrophobiaLevel3 : MonoBehaviour
{
    public GameObject avisoUI;
    private bool avisoAtivo = false;

    public void LoadAcrophobiaLevel3(int opcao)
    {
        if (opcao == 1 || opcao == 2)
        {
            SceneManager.LoadScene("AcrophobiaLevel3");
        }
        else if (opcao == 3 || opcao == 4)
        {
            if (!avisoAtivo)
            {
                avisoUI.SetActive(true);
                avisoAtivo = true;
            }
            else
            {
                SceneManager.LoadScene("AcrophobiaLevel3");
            }
        }
        else if (opcao == 5)
        {
            StartCoroutine(MostrarAvisoEFechar());
        }
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
}
