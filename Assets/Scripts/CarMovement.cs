using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [Header("Pontos de Movimento")]
    public Transform pointA;  // Ponto de partida
    public Transform pointB;  // Ponto de destino
    
    [Header("Configurações do Movimento")]
    public float speed = 5f;  // Velocidade do carro
    public float rotationSpeed = 5f;  // Velocidade de rotação
    public float arrivalThreshold = 0.5f;  // Distância para considerar que chegou
    
    private bool movingToB = true;  // Direção do movimento
    private Vector3 targetPosition;  // Posição alvo atual

    void Start()
    {
        // Começa no ponto A
        if (pointA != null)
        {
            transform.position = pointA.position;
        }
        UpdateTargetPosition();
    }

    void Update()
    {
        // Verifica se os pontos estão configurados
        if (pointA == null || pointB == null)
        {
            Debug.LogWarning("Pontos A ou B não estão configurados no inspector!");
            return;
        }

        // Move o carro em direção ao alvo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Rotaciona o carro para olhar na direção do movimento
        Vector3 direction = (targetPosition - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Verifica se chegou ao destino
        if (Vector3.Distance(transform.position, targetPosition) < arrivalThreshold)
        {
            // Alterna a direção do movimento
            movingToB = !movingToB;
            UpdateTargetPosition();
            
            // Se voltou para A, pode adicionar um pequeno delay ou efeito aqui
            if (!movingToB)
            {
                // Opcional: reinicia completamente (teleporta) para o ponto A
                // transform.position = pointA.position;
                // transform.rotation = pointA.rotation;
            }
        }
    }

    void UpdateTargetPosition()
    {
        // Atualiza a posição alvo baseado na direção atual
        targetPosition = movingToB ? pointB.position : pointA.position;
    }

    // Método para visualizar os pontos no editor
    void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(pointA.position, 0.5f);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(pointB.position, 0.5f);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(pointA.position, pointB.position);
        }
    }
}