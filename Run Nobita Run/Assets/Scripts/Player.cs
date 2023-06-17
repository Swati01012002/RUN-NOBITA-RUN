using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float moveSpeed;
    public Animator animator;

    private int desiredLane = 1;
    public float laneDistance = 4f;

    public float jumpForce;
    public float Gravity = -20;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        direction.z = moveSpeed;

        direction.y += Gravity * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            desiredLane++;
            if(desiredLane==3)
               desiredLane = 2;
        }

        else if(Input.GetKeyDown(KeyCode.D))
        {
            desiredLane--;
            if(desiredLane==-1)
               desiredLane = 0;
        }

        Vector3 targetPosition = transform.position.z *transform.forward + transform.position.y * transform.up;
        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if(desiredLane == 2){
            targetPosition += Vector3.right * laneDistance;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
         //transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
        animator.SetTrigger("jump");
    }
}
