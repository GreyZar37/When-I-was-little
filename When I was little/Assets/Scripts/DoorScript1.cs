using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript1 : MonoBehaviour
{
    public string doorName;
    public bool nearADoor = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nearADoor == true && Input.GetKeyDown(KeyCode.E))
        {
            switch (doorName)
            {
                case "BedroomDoor":
                    SceneManager.LoadScene("Bedroom");
                    GameManager.wasInBedroom = true;

                    break;
                case "GraveyardDoor":
                    SceneManager.LoadScene("Graveyard");
                    break;
                case "HallwayDoor":
                    SceneManager.LoadScene("Hallway");
                    break;

                default:
                    break;
            }
           
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        nearADoor = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            nearADoor = false;
    }
}
