using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public GameObject[] positions;
    int longitud =0;

    void Start()
    {
        for(int i=0; i < positions.Length; i++)
        {
            longitud = longitud + 30;
            var posx = Random.Range(-4, 4);
            var posz = Random.Range(20 + (longitud-30), longitud);

            positions[i].transform.position = new Vector3(posx, -0.5f, posz);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
