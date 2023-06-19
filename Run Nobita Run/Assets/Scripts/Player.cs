using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    public SpawnManager spawnManager;
    private Vector3 direction;
    public float moveSpeed;
    public Animator animator;

    //public float minX = -1f; // The minimum X position of the platform
    //public float maxX = 1f; // The maximum X position of the platform

    //private int desiredLane = 1;
    //public float laneDistance = 0.5f;

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
        
            if(SwipeManager.swipeUp)
            {
            Jump();
            }
        
        
        float horizontalInput = 0f;

        if (SwipeManager.swipeLeft)
        {
            horizontalInput = -0.8f; // Move left when 'A' key is pressed
        }
        else if (SwipeManager.swipeRight)
        {
            horizontalInput = 0.8f; // Move right when 'D' key is pressed
        }
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f); // Create a movement vector based on the input

        moveDirection *= moveSpeed / 2; // Apply the movement speed to the direction vector

        controller.Move(moveDirection * Time.deltaTime);

        // Clamp the character's position within the specified range
        //Vector3 clampedPosition = transform.position;
        //clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        //transform.position = clampedPosition;

       /* if(SwipeManager.swipeRight)
        {
            desiredLane++;
            if(desiredLane==3)
               desiredLane = 2;
        }

        if(SwipeManager.swipeLeft)
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
        transform.position = Vector3.Lerp(transform.position, targetPosition, 70 * Time.deltaTime);*/
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

    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEntered();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            GameOver.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("Game Over");
        }
    }
}
