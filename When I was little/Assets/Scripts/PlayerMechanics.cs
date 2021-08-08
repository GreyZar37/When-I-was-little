using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMechanics : MonoBehaviour
{
    public bool ishidden = false;
    public bool nearShelf = false;

    public TextMeshProUGUI text;

    public AudioClip hide;
    AudioSource audioSource;

    Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && ishidden == false && nearShelf == true)
        {
            audioSource.PlayOneShot(hide);
            text.text = "PRESS E TO EXIT";
            ishidden = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            movement.enabled = false;
            movement.rb.constraints = RigidbodyConstraints2D.FreezeAll;
            movement.GetComponent<Collider2D>().isTrigger = true;

        }
        else if( (Input.GetKeyDown(KeyCode.E) && ishidden == true && nearShelf == true))
            {
            text.text = "PRESS E TO HIDE";

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
            nearShelf = true;
            text.text = "PRESS E TO HIDE";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shelf")
        {

            nearShelf = false;
            text.text = "";

        }
    }

}
