using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Animator _anim;
    string particles;
    AudioSource _audio;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _audio = GetComponent<AudioSource>();
        particles = "WookieDeath";
        _audio.time = 1f;
    }
    public void EnemyDeath(int damage)
    {
        GameObject o = PoolingManager.Instance.GetPooledObject(particles);

        o.SetActive(true);
        o.transform.position = new Vector3(transform.position.x, -1, transform.position.z);
        o.transform.SetParent(this.transform);
        _anim.SetBool("Dead", true);
        _audio.Play();
    }
}
