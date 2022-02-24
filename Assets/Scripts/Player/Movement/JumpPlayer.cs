using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    public bool GroundChecker;
    //float timerJump=0;
    public float jump { get; private set; }

    Animator _anim;

    void OnDisable()
    {
        transform.parent.gameObject.GetComponent<InputSystemKeyboard>().OnJump -= Jump;
        gameObject.GetComponent<PlayerDeath>().OnDeath -= Death;
    }

    void Start()
    {
        transform.parent.gameObject.GetComponent<InputSystemKeyboard>().OnJump += Jump;
        gameObject.GetComponent<PlayerDeath>().OnDeath += Death;
        jump = -9.8f;
        _anim = GetComponentInChildren<Animator>();
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == Constants.layerGround)
        {
            GroundChecker = true;
        }
        
    }

    public void Death()
    {
        
        gameObject.GetComponent<PlayerDeath>().OnDeath -= Death;
        Debug.Log("dead");
    }

    // Update is called once per frame
    void Update()
    {
        if (!GroundChecker)
        {
            jump = jump-0.3f;
        }
    }

    public void Jump()
    {
        if (GroundChecker)
        {
            _anim.SetTrigger("Jump");
            jump = 6f;
            GroundChecker = false;
        }
    }
}
