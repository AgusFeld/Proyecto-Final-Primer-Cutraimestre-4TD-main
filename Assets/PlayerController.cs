using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private float jumpForce = 7.50f;
    private float descentForce = -9.50f;
    private bool salto;

    private void Start()
    {   
        salto = false;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody>();

        if (salto == false)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.velocity = Vector3.up * descentForce;
            }
        }
        

        if (salto){
            if(Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.UpArrow)){
                rb.velocity = Vector3.up * jumpForce;
                salto = false;
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                transform.localScale = new Vector3(1, 0.5f, 1);
                transform.position = new Vector3(0, 0.25f, 0);
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position = new Vector3(0, 0.5f, 0);
            }
        }
    }

    void OnCollisionEnter(Collision Collision)
    {
        if(Collision.gameObject.name == "ground")
        {
           salto = true; 
        }
        
    }

    
}
