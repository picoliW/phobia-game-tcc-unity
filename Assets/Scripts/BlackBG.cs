using UnityEngine;

public class BlackBG : MonoBehaviour
{
    void Start()
    {
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        Camera.main.backgroundColor = Color.black;
    }
}
