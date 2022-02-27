using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        Vector3 normpos = Camera.main.WorldToViewportPoint(position);
        if (normpos.x < 0 || normpos.y > 1 || normpos.x > 1 || normpos.y < -0.5f)
        {
            StartCoroutine(DestroyLater());
        }
    }

    IEnumerator DestroyLater()
    {

        yield return new WaitForSeconds(10f);

        gameObject.SetActive(false);
    }
}
