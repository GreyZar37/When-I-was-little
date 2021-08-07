using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DoorScript1 : MonoBehaviour
{
    public string doorName;
    public bool nearADoor = false;

    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     

        if (nearADoor == true && Input.GetKeyDown(KeyCode.E))
        {
            switch (doorName)
            {
                case "BedroomDoor":
                    SceneManager.LoadScene("Bedroom");
                    text.text = "";

                   

                    break;
                case "GraveyardDoor":
                    SceneManager.LoadScene("Graveyard");
                    text.text = "";

                    break;
                case "HallwayDoor":
                    SceneManager.LoadScene("Hallway");
                    GameManager.wasInBedroom = true;
                    text.text = "";
                    break;

                default:
                    break;
            }
           
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (GameManager.wasInBedroom == false)
            {
                text.text = "PRESS E TO ENTER";
            }
            if (GameManager.wasInBedroom == true)
            {
                text.text = "LOCKED";
            }

            nearADoor = true;
        }
          
           
            
    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            text.text = "";
        nearADoor = false;
    }
}
