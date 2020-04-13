using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    
    [SerializeField] GameObject deathFX;
    [SerializeField] float levelLoadDelay = 1f;

    private void OnTriggerEnter(Collider other)
    {
        deathFX.SetActive(true);
        StartDeathSequence();
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
       
        SendMessage("OnPlayerDeath");

    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
