using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDeath : MonoBehaviour
{
    public event Action OnDeath = delegate { };

    Transform playerTrigger;
    GameObject player;
    Animator _anim;
    MovePlayer _move;
    JumpPlayer _jump;
    GameOverChecker _check;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _move = GetComponent<MovePlayer>();
        _jump = GetComponent<JumpPlayer>();
        playerTrigger = GameObject.Find("PlayersTriggers").transform;
        player = GameObject.Find("Players").gameObject;
        _check = player.GetComponent<GameOverChecker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer).Equals("Enemy"))
        {
            if (_check.playersAlive>=2)
            {
                other.gameObject.GetComponent<EnemyHealth>().EnemyDeath(1);
            }
            else
            {
                _move.enabled = false;
                _jump.enabled = false;

                transform.SetParent(playerTrigger);
                _anim.SetTrigger("Death");
                OnDeath();
            }
                
            
        } else if (LayerMask.LayerToName(other.gameObject.layer).Equals("Enemy2"))
            {
            if (_check.playersAlive >= 4)
            {
                other.gameObject.GetComponent<EnemyHealth>().EnemyDeath(1);
            }
            else
            {
                _move.enabled = false;
                _jump.enabled = false;

                transform.SetParent(playerTrigger);
                _anim.SetTrigger("Death");
                OnDeath();
            }
        }
    }
}
