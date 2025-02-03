using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    public float speed = 5f; 
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity; 
    private bool isGrounded;

    public Transform sphere;
    public float radius;
    public LayerMask layerMask;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(sphere.position, radius, layerMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(sphere.position, radius);
    }
}
