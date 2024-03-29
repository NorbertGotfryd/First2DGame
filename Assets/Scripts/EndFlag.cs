﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    public bool finalLevel;
    public string nextSceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // is it the final level?
            if(finalLevel)
            {
                SceneManager.LoadScene(0);
            }
            // do we have a next level?
            else
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
