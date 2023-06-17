using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Animator animator;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        animator.SetFloat("moveSpeed", moveSpeed);
        if(Input.GetButtonDown("Jump")){
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
        
    }

    
    private void Movement()
    {
        float hMove = Input.GetAxis("Horizontal") * moveSpeed /2;
        float vMove = /*Input.GetAxis("Vertical") */  moveSpeed ;      
        transform.Translate(new Vector3(hMove, 0, vMove) * Time.deltaTime); // Moves the transform in the direction and distance of translation  
    }

}
