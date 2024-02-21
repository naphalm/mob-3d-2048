using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    public static ProgressTracker Instance { get; private set; }
    UpgradeTracker tracker;
    public int combinationCounter = 0;
    public int queueCounter = 1;
    public int biggestDice = 0;
    public int score = 0;
    public int maxCombos = 0;


    private int currentCombo = 1;


    private void Start()
    {
        tracker = GetComponent<UpgradeTracker>();
        // Define a method to handle the event
        EventRelay.Dice.Combination.AddListener(OnDiceCombination);
        EventRelay.Board.QueueIncrease.AddListener(OnQueueIncrease);
        EventRelay.Dice.DiceValueChanged.AddListener(BiggestValueTracker);
        EventRelay.Board.Bonus.AddListener(BonusTrack);
    }

    // The method to handle the event
    private void OnDiceCombination(int value, DiceController transform)
    {
        combinationCounter++;
        score += value * currentCombo * 5 + 1;
        tracker.QUpgCheck(combinationCounter);
    }

    private void OnQueueIncrease(int qsize)
    {
        queueCounter = qsize;
    }

    void BiggestValueTracker(int value)
    {
        if (value > biggestDice)
        {
            biggestDice = value;
            tracker.CheckBiggestUpg(value);
            if (value >= 256)
            {
                EventRelay.Board.BiggestDice.Invoke(value);
            }
        }
    }

    void BonusTrack(int combo)
    {
        currentCombo = combo;
        if (combo > maxCombos)
        {
            maxCombos = combo;
        }
    }



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


}
