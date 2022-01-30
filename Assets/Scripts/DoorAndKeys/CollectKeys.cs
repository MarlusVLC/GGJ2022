using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKeys : MonoBehaviour
{
    public int keysCollected;
    private void OnTriggerEnter(Collider collider)
    {
       if (collider.gameObject.CompareTag("Keys"));
       {
           Destroy(collider.gameObject);
           keysCollected += 1;
       } 
    }
}
