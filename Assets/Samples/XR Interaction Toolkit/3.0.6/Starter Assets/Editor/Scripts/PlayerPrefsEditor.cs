using UnityEditor;
using UnityEngine;

public class PlayerPrefsEditor
{
    [MenuItem("Tools/Reset Menu Dialogue")]
    public static void ResetMenuDialogue()
    {
        PlayerPrefs.DeleteKey("MenuDialogueShown");
        PlayerPrefs.Save();
        Debug.Log("MenuDialogueShown resetado com sucesso!");
    }
    
    [MenuItem("Tools/Delete All PlayerPrefs")]
    public static void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Todos os PlayerPrefs foram resetados!");
    }
}