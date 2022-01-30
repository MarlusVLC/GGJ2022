using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private int KeysToCollect;
    [SerializeField] private bool doorIsOpen = false;
    private CollectKeys collectKeys;

    private void Start()
    {
        collectKeys = FindObjectOfType<CollectKeys>();
    }
    private void Update()
    {
        if (collectKeys.keysCollected >= KeysToCollect)
        {
           doorIsOpen = true; 
        }
        else
        {
            doorIsOpen = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.CompareTag("Player"))
        {
            if (doorIsOpen)
            {
                // go to next level
            }
            else
            {
            }
        }
    }
}