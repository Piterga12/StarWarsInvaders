using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    public int _scene;
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(_scene == 4)
        {
            Cursor.visible = true;
        }
        SceneManager.LoadScene(_scene);
    }
}
