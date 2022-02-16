using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    bool active = false;

    public event Action isActive = delegate { };


    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            isActive();
            active = true;
        }
    }
}
