using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    public int playersAlive = 0;
    float cautionTime = 0;
    void OnEnable()
    {
        PlayerColliders.isActive += PlayersCount;
        PlayerDestroyer.isUnactive += PlayersUncount;
    }
    void OnDisable()
    {
        PlayerColliders.isActive -= PlayersCount;
        PlayerDestroyer.isUnactive -= PlayersUncount;
    }


    void PlayersCount()
    {
        if (cautionTime <= 0)
        {
            //Debug.Log(playersAlive);
            playersAlive++;
            cautionTime = 1;
        }
    }
    void PlayersUncount()
    {
        playersAlive--;
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
