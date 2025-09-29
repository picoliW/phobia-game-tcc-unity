using UnityEngine;

public class VRPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraRig;
    public Transform playerHead;
    public float rotationSpeed = 10f;
    
    private bool rotationEnabled = true;
    private Rigidbody rb;

    void Start()
    {
        rb = cameraRig.GetComponent<Rigidbody>();
        if(rb == null)
        {
            Debug.LogError("Rigidbody not found on cameraRig!");
        }
    }

    void FixedUpdate()
    {
        Vector2 moveInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 moveDirection = playerHead.forward * moveInput.y + playerHead.right * moveInput.x;
        moveDirection.y = 0;

        if (rb != null)
        {
            Vector3 velocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
            rb.linearVelocity = velocity;
        }

        float rotationInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
        
        if (Mathf.Abs(rotationInput) > 0.2f && rotationEnabled)
        {
            cameraRig.RotateAround(playerHead.position, Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);
        }
        
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
        {
            rotationEnabled = !rotationEnabled;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colidiu com: " + collision.gameObject.name);
    }
}
