using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool wasInBedroom = false;
    public GameObject bedroomDoor;
  
    // Start is called before the first frame update
    void Start()
    {
        print(wasInBedroom);
    }

    // Update is called once per frame
    void Update()
    {
        if(wasInBedroom == true)
        {
            bedroomDoor.GetComponent<DoorScript1>().enabled = false;
        }
    }
}
