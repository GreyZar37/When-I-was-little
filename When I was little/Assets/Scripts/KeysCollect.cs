using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysCollect : MonoBehaviour
{
    public static int keysCollected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            keysCollected++;
        }
    }
}
