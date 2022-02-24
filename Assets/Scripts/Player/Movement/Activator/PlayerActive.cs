using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActive : MonoBehaviour
{
    MovePlayer _move;
    JumpPlayer _jump;
    bool active=false;
    void Start()
    {
        _move = GetComponent<MovePlayer>();
        _jump = GetComponent<JumpPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.layer == Constants.layerPlayer && !active)
        {
            _move.enabled = true;
            _jump.enabled = true;
            active = true;
        }
    }
}
