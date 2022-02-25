using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Animator _anim;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }
    public void EnemyDeath(int damage)
    {
        _anim.SetBool("Dead", true);
    }
}
