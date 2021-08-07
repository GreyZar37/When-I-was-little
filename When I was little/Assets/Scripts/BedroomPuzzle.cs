using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomPuzzle : MonoBehaviour
{

   public bool hasBucket;
   public bool hasWaterInBucket;
   public bool hasPoisionInBucket;

    bool doorIsclosed = true;

    public bool nearBucket;
    public bool nearWater;
    public bool nearPoision;
    public bool nearFleshWall;

    GameObject bucket, water, poision;
    GameObject[] fleshWalls;
    GameObject door;

    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(water);
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
            default:
                break;
        }

    }
}
