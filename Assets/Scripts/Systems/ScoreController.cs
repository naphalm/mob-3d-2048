using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// using


public class ScoreController : ScreenSizeHandle
{
    public static ScoreController instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    int score = 0;
    int highScore = 0;

    private void Awake()
    {
        instance = this;
        EventRelay.Dice.Combination.AddListener(OnDiceCombination);
        EventRelay.Screen.LandscapeMode.AddListener(OnLandscapeMode);
        EventRelay.Screen.PortraitMode.AddListener(OnPortraitMode);

        highScore = PlayerPrefs.GetInt("highscore");
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
    }

    private void OnDiceCombination(int value, Transform transform)
    {
        AddScore(value * 10 + 1);
    }

    // Update is called once per frame
    public void AddScore(int vscore)
    {
        score += vscore;
        CheckHiScore();
        UpdateScoreText();

    }

    private void CheckHiScore()
    {
        if (score > highScore)
        {
            highScore = score;
            SaveHiScore();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
    }

    private void SaveHiScore()
    {
        PlayerPrefs.SetInt("highscore", highScore);
    }

    protected override void OnPortraitMode()
    {
        transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        transform.localPosition = new Vector3(-650, 100, 0);
    }

    protected override void OnLandscapeMode()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.localPosition = new Vector3(-650, 300, 0);

    }

}