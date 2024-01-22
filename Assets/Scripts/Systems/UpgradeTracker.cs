using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpgradeTracker : MonoBehaviour
{

    QueueUpgrade qUpg = new();
    BiggestDice bigUpg = new();

    ProgressTracker pT;

    private void Start()
    {
        pT = GetComponent<ProgressTracker>();
    }

    public void QUpgCheck(int combinations)
    {
        if (qUpg.qUpgLevel.ContainsKey(combinations))
        {
            EventRelay.Board.QueueIncrease.Invoke(qUpg.qUpgLevel[combinations]);
        }
    }

    public void CheckBiggestUpg(int value)
    {
        if (bigUpg.biggestDice.ContainsKey(value))
        {
            BoardManager.Instance.maxPow2 = bigUpg.biggestDice[value];

        }
    }
}

// [System.Serializable]
public class QueueUpgrade
{
    public Dictionary<int, int> qUpgLevel = new();
    public QueueUpgrade()
    {
        qUpgLevel.Add(10, 2);
        qUpgLevel.Add(80, 3);
        qUpgLevel.Add(200, 4);
        qUpgLevel.Add(350, 5);
        qUpgLevel.Add(500, 6);
    }
}

public class BiggestDice
{
    public Dictionary<int, int> biggestDice = new();
    public BiggestDice()
    {
        biggestDice.Add(1024, 8);
        biggestDice.Add(4096, 9);
        biggestDice.Add(8192, 10);
    }
}
