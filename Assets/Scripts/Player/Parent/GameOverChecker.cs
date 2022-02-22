using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    int playersAlive = 0;
    void OnEnable()
    {
        GetComponentInChildren<HealthSystem>().isActive += PlayersCount;
    }
    void OnDisable()
    {
        GetComponentInChildren<HealthSystem>().isActive -= PlayersCount;
    }


    void PlayersCount()
    {  
        Debug.Log(playersAlive);
        playersAlive++;
    }
    void Update()
    {
        if (playersAlive == 0)
        {
           Debug.Log(playersAlive);
        }
        
    }
}
