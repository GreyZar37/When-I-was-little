using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum state
{
    idle, follow
}

public class AiController : MonoBehaviour
{
   
    Rigidbody2D rb2D;

    float walkSpeed = 2f;
    float chaseSpeed = 6f;
    public float distance;
    public float offset;

    public float distanceFromPlayerToChaseNeeded = 10;
   
    state States;
   
    public Transform wallDedection;

  
   public  bool facingRight = true;

    public Transform playerTranform;

    PlayerMechanics mechanics;

    // Start is called before the first frame update
    void Start()
    {
        playerTranform = GameObject.FindGameObjectWithTag("Player").transform;
        mechanics = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMechanics>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        conculateDistance();


    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if(States == state.idle)
        {
            idle();
        }
        if(States == state.follow)
        {
            follow();
        }
    }

    void flip()
    {
        if(facingRight == true)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            facingRight = false;
        }
        else if(facingRight == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = true;
        }
       
        
    }
    void idle()
    {
        RaycastHit2D hit = Physics2D.Raycast(wallDedection.position, transform.right, distance);

        if (hit.collider != null)
        {
            if (hit.transform.tag == "Wall")
            {
                flip();
            }

        }
        transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
    }
    void follow()
    {
        transform.Translate(Vector2.right * chaseSpeed * Time.deltaTime);
    }
    void conculateDistance()
    {
        Vector2 vectorToPlayer = transform.position - playerTranform.transform.position;
        if (facingRight)
        {
            if (vectorToPlayer.x > 0 || vectorToPlayer.x < -distanceFromPlayerToChaseNeeded)
            {
                States = state.idle;
            }
            else if (vectorToPlayer.x < 0 && vectorToPlayer.x > -distanceFromPlayerToChaseNeeded && mechanics.ishidden == false)
            {
                States = state.follow;
            }
        }
        else if (facingRight == false)
        {
            if (vectorToPlayer.x < 0 || vectorToPlayer.x > distanceFromPlayerToChaseNeeded)
            {
                States = state.idle;
                print("idle");

            }
            else if (vectorToPlayer.x > 0 && vectorToPlayer.x < distanceFromPlayerToChaseNeeded && mechanics.ishidden == false)
            {
                States = state.follow;
                print("Follow");
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }
}
