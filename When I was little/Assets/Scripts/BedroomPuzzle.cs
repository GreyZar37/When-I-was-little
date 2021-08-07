using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BedroomPuzzle : MonoBehaviour
{

   public bool hasBucket;
   public bool hasWaterInBucket;
   public bool hasPoisionInBucket;
    public bool onString;

    float vertical;

    bool doorIsclosed = true;

    public bool nearBucket;
    public bool nearWater;
    public bool nearPoision;
    public bool nearFleshWall;
    public bool nearString;

    GameObject bucket, poision;
    GameObject[] fleshWalls;
    GameObject door;

    Movement movement;

    public TextMeshProUGUI text;
    public TextMeshProUGUI textInfo;
    

    // Start is called before the first frame update
    void Start()
    {
        GameManager.wasInBedroom = true;
        movement = GetComponent<Movement>();
        doorIsclosed = true;
        bucket = GameObject.FindGameObjectWithTag("Bucket");
        door = GameObject.FindGameObjectWithTag("Door");
        poision = GameObject.FindGameObjectWithTag("Poision");
        fleshWalls = GameObject.FindGameObjectsWithTag("FleshWall");

    }

    // Update is called once per frame
    void Update()
    {

        if (doorIsclosed == true)
        {

            GameManager.wasInBedroom = true;
            door.GetComponent<DoorScript1>().enabled = false;

        }
        else if (doorIsclosed == false)
        {
            GameManager.wasInBedroom = false;
            door.GetComponent<DoorScript1>().enabled = true;


        }


        if (nearBucket == true && Input.GetKeyDown(KeyCode.E))
        {
            hasBucket = true;
            text.text = "";

            Destroy(bucket);
        }
        
        if(nearWater == true && Input.GetKeyDown(KeyCode.E) && hasBucket == true)
        {
            hasWaterInBucket = true;
            text.text = "";

        }
        else if(nearWater == true && Input.GetKeyDown(KeyCode.E) && hasBucket == false)
        {
            textInfo.text = "I NEED A BUCKET";
        }


        if (nearPoision == true && Input.GetKeyDown(KeyCode.E) && hasBucket == true && hasWaterInBucket)
        {
            hasPoisionInBucket = true;
            text.text = "";

            Destroy(poision);
        }
        else if(nearPoision == true && Input.GetKeyDown(KeyCode.E) && hasBucket == true && hasWaterInBucket == false)
        {
            textInfo.text = "I NEED TO BLEND THIS POISION WITH WATER";
        }
        else if(nearPoision == true && Input.GetKeyDown(KeyCode.E) && hasBucket == false)
        {
            textInfo.text = "I NEED A BUCKET";
        }


        if (nearFleshWall == true && Input.GetKeyDown(KeyCode.E) && hasBucket == true && hasWaterInBucket && hasPoisionInBucket)
        {
            for (int i = 0; i < fleshWalls.Length; i++)
            {
                Destroy(fleshWalls[i]);
                doorIsclosed = false;
            }
            
        }
        else if(nearFleshWall == true && Input.GetKeyDown(KeyCode.E))
        {
            textInfo.text = "I NEED SOMETHING TO KILL IT WITH";
        }
       
        
        
        
        
        if(nearString == true && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            onString = true;
        }
        else if( nearString == false)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
            onString = false;
          

        }

        if (onString == true)
        {
            text.text = "";

            vertical = Input.GetAxis("Vertical");
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, vertical * 3);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Bucket":
                text.text = "PRESS E TO INTERACT";
                nearBucket = true;

                break;

            case "Water":
                nearWater = true;
                text.text = "PRESS E TO INTERACT";

                break;

            case "Poision":
                text.text = "PRESS E TO INTERACT";

                nearPoision = true;

                break;

            case "FleshWall":
                text.text = "PRESS E TO INTERACT";

                nearFleshWall = true;

                break;

            case "String":
                text.text = "PRESS E TO CLIMP";

                nearString = true;

                break;

            default:
                break;
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bucket":
                text.text = "";
                textInfo.text = "";
                nearBucket = false;

                break;
            case "Water":
                text.text = "";
                textInfo.text = "";

                nearWater = false;

                break;
            case "Poision":

                nearPoision = false;
                text.text = "";
                textInfo.text = "";

                break;
           
            case "FleshWall":
                text.text = "";
                textInfo.text = "";

                nearFleshWall = false;

                break;

            case "String":
                text.text = "";
                textInfo.text = "";

                nearString = false;
                break;
            default:
                break;
        }

    }
}
