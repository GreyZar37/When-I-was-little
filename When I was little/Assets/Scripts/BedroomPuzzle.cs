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

    GameObject bucket, water, poision;
    GameObject[] fleshWalls;
    GameObject door;

    Movement movement;

    public TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        doorIsclosed = true;
        bucket = GameObject.FindGameObjectWithTag("Bucket");
        water = GameObject.FindGameObjectWithTag("Water");
        door = GameObject.FindGameObjectWithTag("Door");
        poision = GameObject.FindGameObjectWithTag("Poision");
        fleshWalls = GameObject.FindGameObjectsWithTag("FleshWall");

    }

    // Update is called once per frame
    void Update()
    {
        if(doorIsclosed == true)
        {
            door.GetComponent<DoorScript1>().enabled = false;
        }
        else if(doorIsclosed == false)
        {
            door.GetComponent<DoorScript1>().enabled = true;

        }
        if (nearBucket == true && Input.GetKeyDown(KeyCode.E))
        {
            hasBucket = true;
            Destroy(bucket);
        }
        
        if(nearWater == true && Input.GetKeyDown(KeyCode.E) && hasBucket == true)
        {
            hasWaterInBucket = true;
        }
        if(nearPoision == true && Input.GetKeyDown(KeyCode.E) && hasBucket == true && hasWaterInBucket)
        {
            hasPoisionInBucket = true;
            Destroy(poision);
        }
        if (nearFleshWall == true && Input.GetKeyDown(KeyCode.E) && hasBucket == true && hasWaterInBucket && hasPoisionInBucket)
        {
            for (int i = 0; i < fleshWalls.Length; i++)
            {
                Destroy(fleshWalls[i]);
                doorIsclosed = false;
            }
            
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

                nearBucket = true;

                break;

            case "Water":
                nearWater = true;

                break;

            case "Poision":

                nearPoision = true;

                break;

            case "FleshWall":

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

                nearBucket = false;

                break;
            case "Water":

                nearWater = false;

                break;
            case "Poision":

                nearPoision = false;

                break;
           
            case "FleshWall":

                nearFleshWall = false;

                break;

            case "String":
                text.text = "";

                nearString = false;
                break;
            default:
                break;
        }

    }
}
