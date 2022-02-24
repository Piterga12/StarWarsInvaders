using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    public string trooper;
    public Transform[] positions;
    int actualPos=0;
    float startTimer = 0.5f;
    bool initial = true;

    private void Update()
    {
        if (startTimer <= 0 && initial)
        {
            StartCoroutine(GenerateTrooper());
            initial = false;
        }
        else
        {
            startTimer = startTimer - Time.deltaTime;       
        }
    }

    IEnumerator GenerateTrooper()
    {
        GameObject o = PoolingManager.Instance.GetPooledObject(trooper);

        o.SetActive(true);
        o.transform.position = positions[actualPos].position;
        actualPos++;

        yield return new WaitForSeconds(3f);

        if (actualPos < 9)
        {
            StartCoroutine(GenerateTrooper());
        }
    }
}
