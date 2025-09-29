using UnityEngine;

public class PortaController : MonoBehaviour
{
    private Animator animator;
    private bool aberta = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Pressione "E" para interagir com a porta
        {
            if (aberta)
            {
                animator.SetTrigger("Fechar");
            }
            else
            {
                animator.SetTrigger("Abrir");
            }
            aberta = !aberta; // Alterna o estado da porta
        }
    }
}
