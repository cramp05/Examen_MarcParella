using UnityEngine;
Using UnityEngine.InputSystem; //para usar la libreria de imput sistem


public class PlayerControler : MonoBehaviour
{
    public Rigidbody2d rBody2D; //variable para contontrolar el rigidvody
    private InputAction moveAction; //Almacenamos los imputs de las teclas de movimiento
    public Vector2 moveDirection; //Almacenamos la direccion se mueve el mario


    public float movementSpeed = 5f; //para poder controlar la velocidad de movimiento


    public float jumpForce = 10; //para controlar la fuerza da salto
    private InputAction jumpAction; //almacenamos los imputs de la tecla de salto


    private GroundSensor sensor; //el GroundSensor lo tenemos que esctivir como sale en lo de public clas del scrpts de ground sensor


    private SpriteRenderer renderer; //para que almacena hacia que lado se flipea el personaje mario


    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2d>(); //Asignamos el rigid body


        moveAction = InputSystem.actions["Move"]; //para asiganr a las teclas de movimiento del imput system
        jumpAction = InputSystem.actions["Jump"]; // para asiganr a las teclas de salto del imput system


        sensor = GetComponentInChildren<GroundSensor>(); //Para asignar el script del GroundSensora esta variable
    }
    void Start()
    {
       
    }
    void Update()
    {
        moveDirection = moveAction.ReadValue<Vector2>; //vinculamos el      move direction con lo que pulsamos en el moveAction para saber derecha o izquierda


        if(jumpAction.WasPressedThisFrame() && sensor.isGrouned) //un if para que mire si el boton esta pulsado y el sensor GroundSensor del mario detecta que estamos en el suelo
        {
            rBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //para mover el salto
        }


        if(moveDirection.x > 0) //si la direccion es derecha o izquierda hacemos que mire el mario en cada direccion
        {
            render.flipX = false;
        }
        else if(moveDirection.x < 0)
        {
            render.flipX = true;
        }
    }
    void FixedUpdate()
    {
        rBody2D.linearVelocity = new Vector2(moveDirection.x * movementSpeed, rBody2D.linearVelocity.y); //Esto modifica/controla la velocidad
        // (cojemos el valor del moveDirection y lo multiplica por el numero que tengamos en el movent sped para calcular la velocidad a la que se movera hacia los lados,
        //para mover en arriva y abajo ponemos que lo muevo con el rigid rBody2D que vasicamente es dejarlo qeu no haga nada)
    }
}

