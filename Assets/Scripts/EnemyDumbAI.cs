using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDumbAI : MonoBehaviour
{

    //VARIABLE FOR MOVEMENT
    public float speed;

    //VARIABLE FOR HEALTH
    public int health = 1;

    //VARIABLE FOR TIMERS
    public float timer;

    //VARIABLE FOR BOOLEANS
    public bool facingRight = true;

    public PlayerController playerController;

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
        myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);

        //transform.Translate(Vector3.right * speed * Time.deltaTime);
        timer += Time.deltaTime;

        if (timer > 3f && facingRight)
        {
            speed = -speed;
            timer = 0f;
            facingRight = !facingRight;
            transform.localScale = new Vector2(-1, 1);

        }

        if (timer > 3f && !facingRight)
        {
            speed = -speed;
            timer = 0f;
            facingRight = !facingRight;
            transform.localScale = new Vector2(1, 1);

        }

        myAnimator.SetFloat("Hor", myRigidbody.velocity.x);

    }

}
