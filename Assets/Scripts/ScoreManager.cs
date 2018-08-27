using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    //public Text scoreText;

    private int score;

    public void IncreaseScore()
    {
        score++;
        Debug.Log("Score: " + score.ToString());
        //scoreText.text = score.ToString();
    }
}
