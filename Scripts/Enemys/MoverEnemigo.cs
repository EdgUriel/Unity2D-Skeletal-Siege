using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnemigo : MonoBehaviour {
public Transform target; 
[SerializeField] public float speed; 
private Rigidbody2D body;

private Vector3 start, end; 
    // Start is called before the first frame update
    void Awake() {
        body = GetComponent<Rigidbody2D>(); // Traer los componentes del personaje

        if(target != null) {
            target.parent = null; // Limpia su presedencia, que no se mueva con la referencia de alguien más. 
            start = transform.position; // 
            end = target.position; 
        }
    }

    // Update is called once per frame

void Update(){

    
}


    void FixedUpdate() {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip player when moving left or right
        if(horizontalInput > 0.01f)
            transform.localScale = new Vector3(3, 1, 1);
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-3, 1, 1);



        if(target != null){
            float fixedSpeed = speed * Time.deltaTime; //Expresar una velocidad en función del reloj, obtener la hora de unity
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }

        if (transform.position == target.position) {
            target.position = (target.position == start) ? end : start; 
        }

    }
}
