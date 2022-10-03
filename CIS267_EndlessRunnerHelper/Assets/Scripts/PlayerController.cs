using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Attached to player object
public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody2D playerRigidBody;
    private float inputHorizontal;
    //jumpForce set to 20
    //gravity scale on player set to 5
    public float jumpForce;
    private bool isGrounded;
    private PlayerScore pScore;

    //Connection made in Unity editor
    public GameObject GameDriver;

    private ScoreGUI scoreGUI;

    // Start is called before the first frame update
    void Start()
    {
        //I can only get this component using the following line of code
        //becuase the rigidbody2d is attached to the player and this script
        //is also attached to the player
        playerRigidBody = GetComponent<Rigidbody2D>();

        pScore = GetComponent<PlayerScore>();

        scoreGUI = GameDriver.GetComponent<ScoreGUI>();

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //moves an object but will ignore collisions
        //must use Time.deltaTime so that we are moving the object based on time and not frame rate.
        //transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);


        movePlayerLateral();
        jump();
        
    }

    private void movePlayerLateral()
    {
        //Value returned will be 0, 1, or -1 depending on what button is pressed
        //no button pressed: 0 right arrow/d: 1 left arrow/a: -1
        //"Horizontal" is defined in the input section of project settings
        inputHorizontal = Input.GetAxisRaw("Horizontal");


        //apply a velocity to the player
        //Vector2 takes two arguments x and y
        //add an x velocity to the player
        //keep the y velocidty the same as what it currently is
        //no need for time.deltaTime becuase rigidbody2d handles this on its own
        playerRigidBody.velocity = new Vector2(movementSpeed * inputHorizontal, playerRigidBody.velocity.y);

        flipPlayer(inputHorizontal);
    }

    private void flipPlayer(float input)
    {
        if(input > 0)
        {
            //transform.eulerAngles = new Vector2(0,0);
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
        else if(input < 0)
        {
            //transform.eulerAngles = new Vector3(0,180,0);
            transform.localRotation = Quaternion.Euler(0,180,0);
        }
    }

    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            playerRigidBody.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        //tag the platform with the ground tag and see if I am currently grounded.
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        //tag the platform with the ground tag and see if I am currently not grounded.
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        
    }

    //used for collisions with collectables.
    //Collectables have isTrigger selected on their collider.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Collectable"))
        {
            //increment or decement score depending on which collectable we collided with.
            //get the CollectableInfo.cs script that is attached to the script that we ran into
            //get the value of that collectable using the getCollectableValue() function
            pScore.setPlayerScore(other.gameObject.GetComponent<CollectableInfo>().getCollectableValue());
            //change the GUI text to the current score
            scoreGUI.setScoreGUI(pScore.getPlayerScore());
            //destroy the collectable that we ran into
            Destroy(other.gameObject);

            //Testing
            //Debug.Log("PlayerController: " + pScore.getPlayerScore());
        }
    }
}
