using Unity.VisualScripting;
using UnityEngine;

public class Playermovment : MonoBehaviour
{
    [HideInInspector] public static Playermovment instance;

    [Header("Settings")]
    float MouseSensitivity = 2f;
    public Camera cam;
    [SerializeField] float cameraFOV = 80f;

    [Header("Player - Movment")]
    [SerializeField] float WalkSpeed = 1f;
    [SerializeField] float sprintSpeed = 0;
    [SerializeField] float jumpForce = 2f;
    [SerializeField] float gravity = -9.81f;

    [Header("Movment - Additional")]
    [Tooltip("Helps to add Speed to the Player-Walkspeed!")] public float additionalSpeed = 1f;
    [Tooltip("Helps to add Jumpheight to the Player-Jumpheight!")] public float additionalJump = 0f;


    [Header("Auto-Assigned")]
    [SerializeField] CharacterController player;
    bool isGrounded = false;
    float Vertical_Rotation = 0f;
    float velocityY;
    Vector3 move;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        player = GetComponent<CharacterController>();
        cameraFOV = cam.fieldOfView;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        CameraMovment();
        PlayerMovment();
    }

    void CameraMovment()
    {
        // Gets the Axis
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        Vertical_Rotation -= mouseY;
        
        // Clamps the value (Important!)
        Vertical_Rotation = Mathf.Clamp(Vertical_Rotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(Vertical_Rotation, 0f, 0f);
    }

    void PlayerMovment()
    {
        // Gets the Movement Axis
        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");

        move = transform.right * movementX + transform.forward * movementZ;
        
        // Calculates the Speed
        float currentSpeed = WalkSpeed + additionalSpeed;

        // If Player is Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= sprintSpeed;
        }

        isGrounded = player.isGrounded;
        // Checks if rhe player is on ground
        if (isGrounded)
        {
            velocityY = -2f; 
            // Jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocityY = jumpForce + additionalJump;
            }
        }

        velocityY += gravity * Time.deltaTime;
        move.y = velocityY;

        Vector3 horizontalMove = move * currentSpeed;
        horizontalMove.y = velocityY;

        player.Move(horizontalMove * Time.deltaTime);
    }
}
