using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDeath : MonoBehaviour
{
    public event Action OnDeath = delegate { };
    public static event Action isUnActive = delegate { };

    Transform playerTrigger;
    Animator _anim;
    MovePlayer _move;
    JumpPlayer _jump;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _move = GetComponent<MovePlayer>();
        _jump = GetComponent<JumpPlayer>();
        playerTrigger = GameObject.Find("PlayersTriggers").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer).Equals("Enemy"))
        {
            _move.enabled = false;
            _jump.enabled = false;

            transform.SetParent(playerTrigger);
            _anim.SetTrigger("Death");
            OnDeath();
            isUnActive();
            
        } else if (LayerMask.LayerToName(other.gameObject.layer).Equals("Enemy2"))
            {
                _move.enabled = false;
                _jump.enabled = false;

                transform.SetParent(playerTrigger);
                _anim.SetTrigger("Death");
                OnDeath();
                isUnActive();

            }
    }
}
