using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_Movement : MonoBehaviour
{

    public CharacterController player ;

    private Vector3 direction = new Vector3(0, 0, -10); // Movement vector

    // Inputs for left and right movement 
    private bool lane1 = false, lane2 = false, lane3 = false;
    private float slide;

    // Inputs for jump and sliding mechanism
    private float jumpForce = 15f;
    private float gravity = 12f;
    public float verticalVelocity = -0.01f;
    private bool isGrounded;
    private bool air = true;

    // To store inputs from device
    private Vector2 touchStart;
    private Vector2 touchCurrent;
    private Vector2 touchEnd;
    private float swipeRange = 50f;
    private float tapRange = 10f;
    private bool stopTouch = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        slide = 250f;
        lane2 = true;
        direction.z = -15f;

        Settings();

    }

    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            Move();
        }
    }

    private void FixedUpdate()
    {
        if(player)
        {
            // Player Movement in given direction
            player.Move(direction * Time.deltaTime * 0.5f);

            // To change face directiction of a player
            Vector3 dir = player.velocity;
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, 0.05f);

            direction.x = 0f;
            direction.y = verticalVelocity;

        }

        Gravity();
    }

    // Get, store and use inputs from device
    void Move()
    {
        // Touch start
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchStart = Input.GetTouch(0).position;
        }

        // Movement detection of touch
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchCurrent = Input.GetTouch(0).position;
            Vector2 distance = touchCurrent - touchStart;

            if(!stopTouch)
            {
                if(distance.x < -swipeRange)
                {
                    SwipeLeft();
                    stopTouch = true;
                }
                else if (distance.x > swipeRange)
                {
                    SwipeRight();
                    stopTouch = true;
                }
                else if(distance.y > swipeRange)
                {
                    Jump();
                    stopTouch = true;
                }
                else if(distance.y < -swipeRange)
                {
                    Slide();
                    stopTouch = true;
                }
            }

        }

        // Touch end
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            touchEnd = Input.GetTouch(0).position;

            Vector2 Distance = touchEnd - touchStart;

            if(Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                //Debug.Log("Tap");
            }
        }
    }

    // Movement of player in left direction
    void SwipeLeft()
    {
        if(lane2 || lane3)
        {
            direction.x = slide ;

            if (lane2)
            {
                lane2 = false;
                lane1 = true;
            }
            else
            {
                lane3 = false;
                lane2 = true;
            }
        }
    }

    // Movement of player in right direction
    void SwipeRight()
    {
        if (lane2 || lane1)
        {  
            direction.x = -slide;

            if (lane2)
            {
                lane2 = false;
                lane3 = true;
            }
            else
            {
                lane1 = false;
                lane2 = true;
            }
        }
    }

    // Jump mechanism
    void Jump()
    {
        Debug.Log("Jump");
        isGrounded = IsGrounded();

        if(isGrounded)
        {
            verticalVelocity = jumpForce ;

            int select = Random.Range(0, 2);
            if(1 == select)
            {
                player.GetComponent<Animator>().SetTrigger("Jump2");
            }
            else
            {
                player.GetComponent<Animator>().SetTrigger("Jump");
            }

            FindObjectOfType<AudioManager>().Play("Jump");
        }
    }

    // Sliding mechanism
    void Slide()
    {
        if (!isGrounded)
        {
            verticalVelocity = -jumpForce;
        }
        else if(isGrounded)
        {
            //player.GetComponent<Animator>().SetTrigger("Slide");
        }
    }

    // To check whether player is grounded or not 
    private bool IsGrounded()
    {
        Ray GroundRay = new Ray(new Vector3(player.bounds.center.x, (player.bounds.center.y - player.bounds.extents.y) + 0.2f, player.bounds.center.z), Vector3.down);
        return Physics.Raycast(GroundRay, 0.2f + 0.1f);
    }

    // To apply gravity or downward force on player when player is not grounded
    void Gravity()
    {
        isGrounded = IsGrounded();

        if(!isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;

            if(verticalVelocity < -1 && air)
            {
                //player.GetComponent<Animator>().SetTrigger("Air");
                Invoke("Grounded", 1f);
                air = false;
            }
        }
    }
    void Grounded()
    {
        verticalVelocity = -0.01f;
        air = true;
    }

    // To apply the changes made in settings menu
    void Settings()
    {
        // Jump settings / Changes in jump height of player
        if (ToggleMovement.bLow)
        {
            jumpForce = 14f;
        }
        else if (ToggleMovement.bMedium)
        {
            jumpForce = 18f;
        }
        else if (ToggleMovement.bHigh)
        {
            jumpForce = 22f;
        }

        // Speed settings / Changes in forward movement of player
        if (ToggleSpeed.bLowSpeed)
        {
            direction.z = -5f;
        }
        else if (ToggleSpeed.bMediumSpeed)
        {
            direction.z = -15f;
        }
        else if (ToggleSpeed.bHighSpeed)
        {
            direction.z = -25f;
        }
    }

    // Add sound while running / Step is called from animation event
    private void Step()
    {
        FindObjectOfType<AudioManager>().Play("Running");
    }

}
