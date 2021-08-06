using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    public bool ishidden = false;
    public bool nearShelf = false;

    Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && ishidden == false && nearShelf == true)
        {
            ishidden = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            movement.enabled = false;
            movement.rb.constraints = RigidbodyConstraints2D.FreezeAll;
            movement.GetComponent<Collider2D>().isTrigger = true;
        }
        else if( (Input.GetKeyDown(KeyCode.E) && ishidden == true && nearShelf == true))
            {
             ishidden = false;
             gameObject.GetComponent<SpriteRenderer>().enabled = true;
             movement.enabled = true;
             movement.transform.position = movement.transform.position;
             movement.rb.constraints = RigidbodyConstraints2D.None;
             movement.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            movement.GetComponent<Collider2D>().isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Shelf")
        {
            print("Enter");
            nearShelf = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shelf")
        {
            print("Exit");

            nearShelf = false;

        }
    }

}
