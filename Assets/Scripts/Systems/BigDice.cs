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
        EventRelay.Screen.LandscapeMode.AddListener(OnLandscapeMode);
        EventRelay.Screen.PortraitMode.AddListener(OnPortraitMode);

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

        dice.PlayFx(false, 0);
        current = dice;
    }

    void OnPortraitMode()
    {
        transform.localPosition = new Vector3(-1.5f, 2.5f, 10);
    }

    void OnLandscapeMode()
    {
        transform.localPosition = new Vector3(8.5f, 4.5f, 8.5f);
    }
}
