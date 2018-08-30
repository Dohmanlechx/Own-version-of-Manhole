﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedestrianController : MonoBehaviour {

    public ScoreManager scoreManager;
    public GameManager gameManager;
    public PlayerController player;

    public List<Transform> positions = new List<Transform>();
    public int currentPosition = 0;
    public static int playerCurrentPosition;
    public float moveDelay = 1f;
    public static int score;
    float lastMoveTime;

	// Use this for initialization
	void Start () {

        scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();
        transform.position = positions[currentPosition].transform.position;
        lastMoveTime = Time.time;

        score = ScoreManager.score;

        StartCoroutine(Move());
	}

    private void Update()
    {
        playerCurrentPosition = PlayerController.currentPosition;
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);
            MoveToNextPosition();
        }
    }

    void MoveToNextPosition()
    {
        currentPosition++;

        if (currentPosition >= positions.Count)
        {
        currentPosition = 0;
        GetComponent<PedestrianController>().gameObject.SetActive(false);
        }
            
        transform.position = positions[currentPosition].transform.position;

        lastMoveTime = Time.time;

        // Checking if pedestrian is standing on the plank (player)
        if (currentPosition == 4 && playerCurrentPosition != 0
            || currentPosition == 7 && playerCurrentPosition != 1
            || currentPosition == 14 && playerCurrentPosition != 2
            || currentPosition == 17 && playerCurrentPosition != 3)
        {
            // Game Over trigger
            GameOver();
        }
        else if (currentPosition == 4 && playerCurrentPosition == 0
            || currentPosition == 7 && playerCurrentPosition == 1
            || currentPosition == 14 && playerCurrentPosition == 2
            || currentPosition == 17 && playerCurrentPosition == 3)
        {
            score = scoreManager.IncreaseScore();
        }
    }

    void GameOver()
    {
        scoreManager.countText.text = "Game over! Your score: " + score.ToString();
        StopAllCoroutines();
        Time.timeScale = 0;
    }
}
