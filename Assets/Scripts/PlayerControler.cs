using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private InputAction moveAction;
    private InputAction jumpAction;
    public Vector2 moveDirection;
    public Rigidbody2D rBody2D;

    public float moveSpeed = 5;
    public float jumpForce = 10;

    private GroundSensor sensor; 
    private SpriteRenderer renderer;

   
    void Awake()
    {
        //sensor = GetComponentsInChildren<"GroundSensor">("GroundSensor");
        rBody2D = GetComponent<Rigidbody2D>(); 


        moveAction = InputSystem.actions["Move"]; 
        jumpAction = InputSystem.actions["Jump"]; 

        moveDirection = moveAction.ReadValue<Vector2>(); 


        //sensor = GetComponentInChildren<GroundSensor>(); 

    }

    
    void Start()
    {
        
    }


    void Update()
    {
         


        if(jumpAction.WasPressedThisFrame() ) //&& sensor.isGrouned
        {
            rBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
        }
    }


    void FixedUpdate()
    {
        rBody2D.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rBody2D.linearVelocity.y);
    }
}
