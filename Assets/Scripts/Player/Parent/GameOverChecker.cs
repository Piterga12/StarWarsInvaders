using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    public int playersAlive = 0;
    float cautionTime = 0;
    public GameObject _death;

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
            _death.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        }

        cautionTime = cautionTime - Time.deltaTime;
    }
}
