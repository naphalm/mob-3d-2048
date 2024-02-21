using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG.Example;

public class BonusTracker : MonoBehaviour
{
    public float initPitch = 2.0f;
    public float secondPitch = 2.2f;
    public float thirdPitch = 2.5f;

    [Header("Timer")]
    public float bonusTime = 2f;


    Coroutine timer;
    private void Awake()
    {
        EventRelay.Dice.Combination.AddListener(OnCombination);

    }

    int counter = 0;
    void OnCombination(int i, DiceController dice)
    {
        counter++;
        HandleBonus(counter, dice);
        if (timer != null)
        {
            StopCoroutine(timer);
        }
        timer = StartCoroutine(Timer());
    }

    void HandleBonus(int counter, DiceController dice)
    {
        EventRelay.Board.Bonus.Invoke(counter);
        dice.PlayFx(true, counter);
        Debug.Log("Bonus counter:" + counter);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(bonusTime);
        counter = 0;
        EventRelay.Board.ResetBonus.Invoke();
    }




}
