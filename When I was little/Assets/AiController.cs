using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum state
{
    idle, follow, attack
}

public class AiController : MonoBehaviour
{
   
    Rigidbody2D rb2D;

    public float speed = 5f;
    public float distance;
    public float offset;
   
    state States;
   
    public Transform wallDedection;

  
    bool facingRight = true;

    public Transform playerTranform;

    // Start is called before the first frame update
    void Start()
    {
        playerTranform = GameObject.FindGameObjectWithTag("Player").transform;
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        States = state.follow;
        if(States == state.idle)
        {
            RaycastHit2D hit = Physics2D.Raycast(wallDedection.position, transform.right, distance);

            if (hit.collider != null)
            {
                if (hit.transform.tag == "Wall")
                {
                    flip();
                }

            }
            movement();
        }
        if(States == state.follow)
        {
            Vector2 vectorToPlayer = transform.position - playerTranform.transform.position;
            if (vectorToPlayer.x <= 1)
            {
                print("Olla");
            }
        }
        if (States == state.attack)
        {

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
    void movement()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
