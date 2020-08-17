using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the player alongside the y axis
/// </summary>

[RequireComponent(typeof(Rigidbody2D))]
public class PadMovement : MonoBehaviour

{
    //movement velocity
    [Tooltip("Velocity in unity units!")]
    [SerializeField] private float velocity = 0.5f;
    
    [Header("pared inferior:")]
    public float ParedInferior;
    [Header("pared superior:")]
    public float ParedSuperior;

    [Header("Controles para el game pad:")] 
    [SerializeField] private KeyCode UpControl;
    [SerializeField] private KeyCode DownControl;

    private Rigidbody2D _rigidbody2D;

    public Vector3 startPosition;

    public float x;
    public float y;
    public float z;

    // Start is called before the first frame update
    void Start()
    {   
        startPosition = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Reset()
    {
        _rigidbody2D.velocity = Vector2.zero;
        transform.position = startPosition;
    }

    //mejora aumenta tamaño cada vez que anota un gol
    public void AumentarTamanio()
    {
        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;

        if (y<4)
        {   
            x += 0.0f;
            y += 0.2f;
            z += 0.0f;
            transform.localScale = new Vector3(x,y,z);
        }
    }

    public void DisminuirTamanio()
    {
        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;
        
        if (y>2)
        {
            x -= 0.0f;
            y -= 0.2f;
            z -= 0.0f;
            transform.localScale = new Vector3(x,y,z);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //leer el control de teclas
        //aplicar movimiento

        //mover hacia arriba 
        if(Input.GetKey(UpControl))
            transform.Translate(x: 0f, y: velocity,z: 0f);

        //mover hacia abajo
        else if (Input.GetKey(DownControl))
            transform.Translate(x: 0f, y: -velocity,z: 0f);

        //if(!_rigidbody2D.Equals(other: null))
        //    _rigidbody2D.AddForce(Vector2.up,ForceMode2D.Impulse);
        //else
        //    {
        //    Debug.LogWarning( message: "el objeto no tiene rigidbody!");
        //    }
        
        //pared eje y
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, ParedInferior, ParedSuperior), transform.position.z);
    }
}
