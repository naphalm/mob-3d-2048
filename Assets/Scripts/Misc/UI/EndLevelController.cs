using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class EndLevelController : MonoBehaviour
{
    public TextMeshProUGUI combinations;
    public TextMeshProUGUI qsize;
    public TextMeshProUGUI score;
    public TextMeshProUGUI biggestDice;


    private void Awake()
    {
        Assert.IsNotNull(combinations);
        Assert.IsNotNull(qsize);
        Assert.IsNotNull(score);
        Assert.IsNotNull(biggestDice);
    }

    void Start()
    {
        EventRelay.GameManager.Death.AddListener(OnLevelEnd);
        gameObject.SetActive(false);
    }

    void OnLevelEnd()
    {
        gameObject.SetActive(true);
        SetData();
    }

    void SetData()
    {
        combinations.text = ProgressTracker.Instance.combinationCounter.ToString();
        qsize.text = ProgressTracker.Instance.queueCounter.ToString();
        score.text = ProgressTracker.Instance.score.ToString();
        biggestDice.text = ProgressTracker.Instance.biggestDice.ToString();
    }

    public void Replay()
    {
        EventRelay.GameManager.Replay.Invoke();
    }

    public void RewardedContinue()
    {
        EventRelay.GameManager.RewardedContinue.Invoke();
        gameObject.SetActive(false);
    }
}
