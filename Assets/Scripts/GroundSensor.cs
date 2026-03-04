using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public GroundSensor isGrouned;

    public bool ground = true;

    void /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        isGrouned = ground;
    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    void OnTriggerEnter2d(Collider2D col)
    {
        ground = true;
    }

    void OnTriggerExid2d(Collider2D col)
    {
        ground = false;
    }
}
