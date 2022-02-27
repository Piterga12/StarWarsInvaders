using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDeath : MonoBehaviour
{
    public event Action OnDeath = delegate { };

    public bool GodMode = false;

    Transform playerTrigger;
    GameObject player;
    Animator _anim;
    MovePlayer _move;
    JumpPlayer _jump;
    GameOverChecker _check;
    AudioSource _audio;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _move = GetComponent<MovePlayer>();
        _audio = GetComponent<AudioSource>();
        _jump = GetComponent<JumpPlayer>();
        playerTrigger = GameObject.Find("PlayersTriggers").transform;
        player = GameObject.Find("Players").gameObject;
        _check = player.GetComponent<GameOverChecker>();
        _audio.time = 0.5f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GodMode = true;
        } else if (Input.GetKeyDown(KeyCode.H))
        {
            GodMode= false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GodMode)
        {
            if (LayerMask.LayerToName(other.gameObject.layer).Equals("Enemy"))
            {
                if (_check.playersAlive >= 2)
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
                    _audio.Play();
                }


            }
            else if (LayerMask.LayerToName(other.gameObject.layer).Equals("Enemy2"))
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
                    _audio.Play();
                }
            }
            else if (LayerMask.LayerToName(other.gameObject.layer).Equals("Obstacles2"))
            {
                _move.enabled = false;
                _jump.enabled = false;

                transform.SetParent(playerTrigger);
                _anim.SetTrigger("Death");
                OnDeath();
                _audio.Play();
            }
        }
    }
}
