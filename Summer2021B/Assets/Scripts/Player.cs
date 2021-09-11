using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject doorObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && doorObject != null)
        {
            DoorScript script = doorObject.GetComponent<DoorScript>();
            if(script!= null)
            {
                script.openDoor();
            }
        }
    }
}
