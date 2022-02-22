using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputSystemKeyboard : MonoBehaviour
{
    public float hor { get; private set; }
    public float ver { get; private set; }

    public event Action OnJump = delegate { };

    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump();
        }
    }
}
