using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDice : MonoBehaviour
{
    DiceSpawner spawner;
    BaseDice current;

    private void Awake()
    {
        spawner = GetComponent<DiceSpawner>();
        EventRelay.Board.BiggestDice.AddListener(OnBiggestDice);
        gameObject.SetActive(false);
    }

    void OnBiggestDice(int value)
    {
        gameObject.SetActive(true);
        Destroy(current?.gameObject);
        var ddice = spawner.SpawnDice();
        ddice.transform.SetParent(transform);
        ddice.transform.SetPositionAndRotation(transform.position, transform.rotation);

        var dice = ddice.GetComponent<DiceController>();

        dice.Value = value;

        dice.PlayFx(false);
        current = dice;
    }
}
