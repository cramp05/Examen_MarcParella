using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControlerMario : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private InputAction moveAction;
    private InputAction jumpAction;
    public Vector2 moveDirection;
    public Rigidbody2d rBody2D;

    public float moveSpeed = 5;
    public float jumpForce = 10;

    private GroundSensor isGrouned; 
    private SpriteRenderer renderer;

   
    void Awake()
    {
        isGrouned = GetComponentsInChildren<"GroundSensor">("GroundSensor");
        rBody2D = GetComponent<Rigidbody2d>(); 


        moveAction = InputSystem.actions["Move"]; 
        jumpAction = InputSystem.actions["Jump"]; 


        sensor = GetComponentInChildren<GroundSensor>(); 

    }

    
    void Start()
    {
        
    }


    void Update()
    {
         moveDirection = moveAction.ReadValue<Vector2>; 


        if(jumpAction.WasPressedThisFrame() && sensor.isGrouned) 
        {
            rBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
        }
    }


    void FixedUpdate()
    {
        rBody2D.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rBody2D.linearVelocity.y);
    }
}
