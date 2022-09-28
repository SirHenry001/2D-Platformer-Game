using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // VARIABLE FOR ENEMY TARGET
    public Transform target;

    //VARIABLE FOR HEALTH
    public int health = 1;

    //VARIABLES FOR SPEED & RANGE
    public float speed;
    public float aggroRange;

    // VECTOR WHICH NEEDED FOR MOVEMENT
    public Vector2 movement;

    //VARIABLES FOR SCRIPTS
    public PlayerController playerController;

    //VARTIABELS FOR COMPONENTS
    public Rigidbody2D myRigidbody;
    public Animator myAnimator;



    private void OnCollisionStay2D(Collision2D collision)
    {
        //if player keeps colliding the enemy, player loses (1) amont life
        if (collision.gameObject.tag == "Player")
        {
            playerController.PlayerHealth(1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, target.position);

        if (distToPlayer < aggroRange)
        {
            Approach();
        }

        myAnimator.SetFloat("Hor", myRigidbody.velocity.x);


    }

    public void Approach()
    {
        if (transform.position.x < target.position.x)
        {
            myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);
            transform.localScale = new Vector2(-1, 1);

        }
        // ENEMY IS ON THE RIGHT SIDE, GO LEFT
        else
        {
            myRigidbody.velocity = new Vector2(-speed, myRigidbody.velocity.y);
            transform.localScale = new Vector2(1, 1);

        }

        myAnimator.SetFloat("Hor", myRigidbody.velocity.x);

    }

}
