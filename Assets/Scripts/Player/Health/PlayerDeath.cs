using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDeath : MonoBehaviour
{
    public event Action OnDeath = delegate { };

    Animator _anim;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer).Equals("Enemy"))
        {
            _anim.SetTrigger("Death");
            OnDeath();
            /*Transform parent = other.transform;
            transform.SetParent(parent);
            Debug.Log("New Parent");*/
        }
    }
}
