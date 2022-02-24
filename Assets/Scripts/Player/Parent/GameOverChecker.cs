using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    int playersAlive = 0;
    float cautionTime = 0;
    void OnEnable()
    {
        PlayerColliders.isActive += PlayersCount;
    }
    void OnDisable()
    {
        PlayerColliders.isActive -= PlayersCount;
    }


    void PlayersCount()
    {
        if (cautionTime <= 0)
        {
            Debug.Log(playersAlive);
            playersAlive++;
            cautionTime = 5;
        }
    }
    void Update()
    {
        if (playersAlive < 0)
        {
           Debug.Log(playersAlive);
        }

        cautionTime = cautionTime - Time.deltaTime;
    }
}
