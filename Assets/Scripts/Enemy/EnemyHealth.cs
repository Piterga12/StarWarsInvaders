using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Animator _anim;
    string particles;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        particles = "WookieDeath";
    }
    public void EnemyDeath(int damage)
    {
        GameObject o = PoolingManager.Instance.GetPooledObject(particles);

        o.SetActive(true);
        o.transform.position = new Vector3(transform.position.x, -1, transform.position.z);
        o.transform.SetParent(this.transform);
        Debug.Log(o.transform.parent.name);
        _anim.SetBool("Dead", true);
    }
}
