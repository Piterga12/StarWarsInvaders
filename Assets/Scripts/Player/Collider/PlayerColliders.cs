using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerColliders : MonoBehaviour
{
    public static event Action isActive = delegate { };
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer).Equals("Player"))
        {
            transform.SetParent(other.transform.parent);
            gameObject.layer = Constants.layerPlayer;
            Debug.Log("WHYYYYY?");
            isActive();
        }
    }
}
