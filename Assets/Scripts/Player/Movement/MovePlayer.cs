using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float sideSpeed;

    CharacterController body;
    Animator _anim;
    Transform _cam;

    private InputSystemKeyboard inputSystem;
    private JumpPlayer jumpPlayer;

    private void OnEnable()
    {
        
    }
    void OnDisable()
    {
        gameObject.GetComponent<PlayerDeath>().OnDeath -= Death;
    }

    void Awake()
    {
        gameObject.GetComponent<PlayerDeath>().OnDeath += Death;
        _anim = GetComponentInChildren<Animator>();
        body = GetComponent<CharacterController>();
        _cam = GameObject.Find("Main Camera").transform;
        jumpPlayer = GetComponent<JumpPlayer>();
        
    }
    void Start()
    {     
        inputSystem = transform.parent.gameObject.GetComponent<InputSystemKeyboard>();
        _anim.SetBool("Run", true);
    }

    public void Death()
    {
        gameObject.GetComponent<PlayerDeath>().OnDeath -= Death;
        Debug.Log("dead");
    }

    // Update is called once per frame
    void Update()
    {
        if(_cam.transform.position.z > transform.position.z - 8)
        {
            speed = 6;
        }
        else
        {
            speed = 4;
        }
        body.Move(new Vector3(sideSpeed*inputSystem.hor, jumpPlayer.jump, speed)*Time.deltaTime);
        if (inputSystem.hor < 0)
        {
            _anim.SetBool("Left", true);
        } else if(inputSystem.hor > 0)
        {
            _anim.SetBool("Right", true);
        }
        else
        {
            _anim.SetBool("Left", false); 
            _anim.SetBool("Right", false);
        }
    }
}
