using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public string[] enemies;
    public Transform[] positions;
    int pos=0;
    int i = 0;
    float timeSpawn=2f;

    private void Start()
    {
        StartCoroutine(GenerateTrooper());
    }
    IEnumerator GenerateTrooper()
    {
        GameObject o = PoolingManager.Instance.GetPooledObject(enemies[i]);

        o.SetActive(true);
        o.transform.position = positions[pos].position;

        pos++;
        if (pos >= 3)
        {
            i = 1;
            timeSpawn = 20f;
        } 

        yield return new WaitForSeconds(timeSpawn);

        StartCoroutine(GenerateTrooper());
    }
}
