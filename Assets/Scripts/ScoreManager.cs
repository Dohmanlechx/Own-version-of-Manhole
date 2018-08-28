using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text countText;

    public static int score;

    private void Start()
    {
        countText.text = "Count: " + score.ToString();
    }

    public void IncreaseScore()
    {
        score++;
        Debug.Log("Score: " + score.ToString());
        countText.text = "Count: " + score.ToString();
    }
}
