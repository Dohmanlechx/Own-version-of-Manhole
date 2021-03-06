﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public ScoreManager scoreManager;

    public GameObject playerPrefab;
    public GameObject pedestrianPrefab;
    GameObject newPlayer;
    GameObject newPedestrian;

    bool level1, level2, level3, levelmax = false;

    public static int score;

    // Use this for initialization
    void Start () {

        score = 0;
        
        // Creating player
        newPlayer = Instantiate(playerPrefab);
        newPlayer.GetComponentInChildren<PlayerController>().gameManager = this;

        // Creating first "wave" of pedestrians
        InvokeRepeating("SpawnPedestrian", 1.5f, 30f);

	}
	
	// Update is called once per frame
	void Update () {
        
        score = ScoreManager.score;

        // More pedestrians spawning while points get higher
        if (score >= 3 && !level1)
        {
            level1 = true;
            CancelInvoke();
            InvokeRepeating("SpawnPedestrian", 3.5f, 12f);
        }
        else if (score >= 11 && !level2)
        {
            level2 = true;
            CancelInvoke();
            InvokeRepeating("SpawnPedestrian", 3f, 8.5f);
        }
        else if (score >= 22 && !level3)
        {
            level3 = true;
            CancelInvoke();
            InvokeRepeating("SpawnPedestrian", 3.5f, 6f);
        }
        else if (score >= 33 && !levelmax)
        {
            levelmax = true;
            CancelInvoke();
            InvokeRepeating("SpawnPedestrian", 3f, 4.5f);
        }
    }

    void SpawnPedestrian()
    {
        newPedestrian = Instantiate(pedestrianPrefab);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        ScoreManager.score = 0;
        scoreManager.SetText();
        Start();
    }
}
