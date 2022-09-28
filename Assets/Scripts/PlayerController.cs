using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //VARIABLES FOR HEALTH
    public int playerHealth;

    //VARIABLES FOR MOVEMENT
    public float speed;
    public float x;
    public float y;
    public bool facingRight;

    //VARIABLES FOR COMPONENTS
    public Rigidbody2D myRigidbody;
    public Animator myAnimator;

    //VARIABLES FOR IMAGES
    public Image healthImage;

    //VARIABLES FOR JUMPING
    public float jumpSpeed;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public bool canJump;
    public Transform feet;
    public float radius = 0.1f;
    public LayerMask layerMask;

    //VARIABLE FOR PLAYER POSITION IN Y AXIS
    public float storedY;

    //VARIABLES FOR SCRIPTS
    public GameManager gameManager;

    //VARIABLES FOR cMOVEMENT LIMITATION
    public float minX;
    public float maxX;

    // Start is called before the first frame update
    void Start()
    {

        //get acces to other scripts
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //define myRigidbody to get Rigidbody2D component in unity
        myRigidbody = GetComponent<Rigidbody2D>();

        //Define myAnimator to get Animator component in Unity
        myAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        y = myRigidbody.velocity.y;
        //myAnimator.SetFloat("Ver", y);

        // PLAYER GRAVITY MULTIPLIES DURING FALLING
        if(y < 0)
        {
            myRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1f) * Time.deltaTime;
        }
        // IF JUMP BUTTON IS RELEASED DURING JUMP, PLAYER FALL DOWN FASTER AND GET SMALLER JUMP
        else if(y > 0 && !Input.GetButton("Jump"))
        {
            myRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1f) * Time.deltaTime;
        }

        //IF SPACE IS PRESSED, PLAYER JUMPS
        if(Input.GetButtonDown("Jump") && canJump == true)
        {
            myRigidbody.velocity = Vector2.up * jumpSpeed;

        }

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX),(transform.position.y));
    }

    private void FixedUpdate()
    {

        //MOVEMENT
        // get horizonatal contorls in unity inputs
        x = Input.GetAxisRaw("Horizontal");

        //define rigidbody movement type
        myRigidbody.velocity = new Vector2(x * speed, myRigidbody.velocity.y);

        //ANIMATOR IN UNITY SET FLOAT 1 OR -1 DEPENDS ON WHERE PLAYER IS MOVING
        myAnimator.SetFloat("Hor", x);
        myAnimator.SetFloat("Ver", myRigidbody.velocity.y);
        myAnimator.SetBool("Reset", canJump);
        


        if (x != 0)
        {
            speed += Time.deltaTime * 15;

            if (speed >= 8f)
            {
                speed = 8f;
            }
        }

        else if (x == 0)
        {
            speed = 3f;
        }
        


        //JUMPING - PLAYER FEET DETECTION
        canJump = Physics2D.OverlapCircle(feet.position, radius, layerMask);

        //PLAYER Y AXIS VALUE/POSITION WHEN GROUND
        if (canJump == true)
        {
            storedY = transform.position.y;
        }

        // PLAYER TURNING
        // if player goes right, it also turns right
        if (x > 0.1f && facingRight == false)
        {
            Flip();
            facingRight = !facingRight;
        }

        //when player goes left, it also turns left
        if (x < -0.1f && facingRight == true)
        {
            Flip();
            facingRight = !facingRight;
        }



    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1f);
    }

    public void PlayerHealth(int health)
    {
        playerHealth -= health;
        healthImage.fillAmount = playerHealth * 0.01f;

        if (playerHealth > 100)
        {
            playerHealth = 100;
        }

        if(playerHealth <= 0)
        {
            gameManager.DeathGame();
        }
    }
}
