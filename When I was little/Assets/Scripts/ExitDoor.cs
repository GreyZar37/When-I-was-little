using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ExitDoor : MonoBehaviour
{
    public TextMeshProUGUI text;
    bool nearADoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(nearADoor);
        if (nearADoor == true && Input.GetKeyDown(KeyCode.E) && KeysCollect.keysCollected == 1)
        {
            SceneManager.LoadScene("Credits");
            text.text = "";

        }
        else if(nearADoor == true && Input.GetKeyDown(KeyCode.E) && KeysCollect.keysCollected == 0)
        {
            text.text = "I NEEED A KEY";
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.text = "PRESS E TO EXIT";

            nearADoor = true;
        }

           
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.text = "";
            nearADoor = false;
        }
          
    }

}
