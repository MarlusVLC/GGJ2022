using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [field: SerializeField] public int KeysToCollect { get; private set;}
    [SerializeField] private bool doorIsOpen = false;
    public int keysCollected;

    public event Action<int> OnCollectKey;

    private void Update()
    {
        if (keysCollected >= KeysToCollect)
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
                Debug.Log("Level finished :}");
            }
            else
            {
            }
        }
    }

    public void CollectKey()
    {
        OnCollectKey?.Invoke(++keysCollected);
    }
}