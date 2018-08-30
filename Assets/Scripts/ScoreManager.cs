using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text countText;

    public static int score;

    private void Start()
    {
        SetText();
    }

    public int IncreaseScore()
    {
        score++;
        SetText();
        return score;
    }

    public void SetText()
    {
        countText.text = "Count: " + score.ToString();
    }
}
