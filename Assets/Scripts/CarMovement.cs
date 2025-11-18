using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [Header("Pontos de Movimento")]
    public Transform pointA;  
    public Transform pointB;  
    
    [Header("Configurações do Movimento")]
    public float speed = 5f;  
    public float rotationSpeed = 5f;  
    public float arrivalThreshold = 0.5f;  
    
    private bool movingToB = true;  
    private Vector3 targetPosition;  

    void Start()
    {
        if (pointA != null)
        {
            transform.position = pointA.position;
        }
        UpdateTargetPosition();
    }

    void Update()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogWarning("Pontos A ou B não estão configurados no inspector!");
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        Vector3 direction = (targetPosition - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, targetPosition) < arrivalThreshold)
        {
            movingToB = !movingToB;
            UpdateTargetPosition();
            
            if (!movingToB)
            {

            }
        }
    }

    void UpdateTargetPosition()
    {
        targetPosition = movingToB ? pointB.position : pointA.position;
    }

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