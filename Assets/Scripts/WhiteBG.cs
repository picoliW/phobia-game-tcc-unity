using UnityEngine;

public class WhiteBG : MonoBehaviour
{
    void Start()
    {
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        Camera.main.backgroundColor = Color.white;
    }
}
