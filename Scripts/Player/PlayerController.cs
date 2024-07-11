using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed; 
    private Rigidbody2D body;
    private Animator anim; 
    private bool grounded; 


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>(); // Traer los componentes del personaje
        anim = GetComponent<Animator>();
        speed = 5;

    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip player when moving left or right
        if(horizontalInput > 0.01f)
            transform.localScale = new Vector3(4, 4, 1);
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-4, 4, 1);

        if(Input.GetKey(KeyCode.Space) && grounded)
            Jump();
        
        //Set animator parameters
        anim.SetBool("isRunning", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
        

    }

    private void Jump(){
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground"){
            grounded = true;
        }
    }

    void onBecameInvisible() {
        transform.position = new Vector3(-3,0,0);
        //body.velocity = 0; 
    }
/*
     private void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.tag == "Suelo"){
            anim.SetBool("pisando", true);
            anim.SetBool("isRunning", 1 != 0);
        }else{
            anim.SetBool("pisando", false);
        }
    }*/

/*
    void FixedUpdate(){ // Para que Update sea más agil 
        float h = Input.GetAxis("Horizontal"); // Leer la entrada, flechitas 
        //Debug.Log(h);
        body.AddForce(Vector2.right * h * speed); //.AddForce para añadir una fuerza (impulso), un vector ocupa magnitud y dirección
        Debug.Log(body.velocity.x); //Mostrar la velocidad de desplazamiento del personaje   
    }

        void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.tag == "Suelo"){
            Debug.Log("Pisando el suelo");
            anim.SetBool("pisando", true);
            anim.SetFloat("vel_x", body.velocity.x);
        }
        else {
            Debug.Log("Chocando contra algo más");
        }
    }*/
}

/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float impulso; 
    private Animator anim; 

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Traer los componentes del personaje
        anim = GetComponent<Animator>();
        impulso = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){ // Para que Update sea más agil 
        float h = Input.GetAxis("Horizontal"); // Leer la entrada, flechitas 
        //Debug.Log(h);
        rb2d.AddForce(Vector2.right * h * impulso); //.AddForce para añadir una fuerza (impulso), un vector ocupa magnitud y dirección
        Debug.Log(rb2d.velocity.x); //Mostrar la velocidad de desplazamiento del personaje   
    }

        void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.tag == "Suelo"){
            Debug.Log("Pisando el suelo");
            anim.SetBool("pisando", true);
            anim.SetFloat("vel_x", rb2d.velocity.x);
        }
        else {
            Debug.Log("Chocando contra algo más");
        }
    }
}

*/