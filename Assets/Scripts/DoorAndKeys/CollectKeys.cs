using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKeys : MonoBehaviour
{
    private OpenDoor openDoor;

    private void Start()
    {
        openDoor = FindObjectOfType<OpenDoor>();
    }
    private void OnTriggerEnter(Collider collider)
    {
       if (collider.gameObject.CompareTag("Player"));
       {
           Destroy(this.gameObject);
           openDoor.keysCollected += 1;
       } 
    }
}
