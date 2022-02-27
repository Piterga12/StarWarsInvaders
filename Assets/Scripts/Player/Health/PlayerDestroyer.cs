using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDestroyer : MonoBehaviour
{
    public static event Action isUnactive = delegate { };
    private Transform playerTrigger;
    MovePlayer _move;
    JumpPlayer _jump;

    private void Start()
    {
        _move = GetComponent<MovePlayer>();
        _jump = GetComponent<JumpPlayer>();
        playerTrigger = GameObject.Find("PlayersTriggers").transform;
    }
    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        Vector3 normpos = Camera.main.WorldToViewportPoint(position);
        if (normpos.x < 0 || normpos.y > 1 || normpos.x > 1 || normpos.y < -0.5f)
        {
            if (gameObject.layer == Constants.layerPlayer)
            {
                isUnactive();
            }
            
            _move.enabled = false;
            _jump.enabled = false;
            gameObject.layer = Constants.layerPlayerChild;
            Debug.Log(gameObject.layer);
            gameObject.SetActive(false);
            transform.SetParent(playerTrigger);
            
        }
    }
}
