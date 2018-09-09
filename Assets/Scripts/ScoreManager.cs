using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public Text countText;
    public TextMeshProUGUI highscoreText;
    public static int score;
    public static int highscore;

    private void Start()
    {
        if (countText != null)
            SetText();

        highscore = PlayerPrefs.GetInt("highscore", highscore);

        if (highscoreText != null)
            highscoreText.text = "Highscore: " + highscore.ToString();
    }

    private void Update()
    {
        if (score > highscore)
        {
            highscore = score;
            //highscoreText.text = "" + score.ToString();

            PlayerPrefs.SetInt("highscore", highscore);
        }
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
