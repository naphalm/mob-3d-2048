using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiceQueue : MonoBehaviour
{
    private DiceSpawner spawner;
    public List<BaseDice> dq = new();
    public int maxHeldDice = 2; // Set your desired maximum number of held dice here


    private void Awake()
    {
        spawner = GetComponent<DiceSpawner>();
        InitializeDiceQueue();
        EventRelay.Board.QueueIncrease.AddListener(UpdateMaxHeldDice);

    }

#if UNITY_EDITOR
    private void Update()
    {
        // Check for the "U" key press
        if (Input.GetKeyDown(KeyCode.U))
        {
            // Call the UpdateMaxHeldDice function with a new value (you can adjust this)
            UpdateMaxHeldDice(maxHeldDice + 1);
        }
    }
#endif

    public BaseDice GetNextDice()
    {

        dq.Add(SpawnNew());

        BaseDice oldestDice = dq[0];
        dq.RemoveAt(0);
        RepositionDice();

        return oldestDice;
    }

    private void InitializeDiceQueue()
    {
        for (int i = 0; i < maxHeldDice; i++)
        {
            BaseDice dice = SpawnNew();
            dq.Add(dice);
        }
        RepositionDice();
    }

    void RepositionDice()
    {
        for (int i = 0; i < dq.Count; i++)
        {
            dq[i].transform.SetLocalPositionAndRotation(new Vector3(i * 1.1f, -i * 0.25f, 0), transform.rotation);
        }
    }

    BaseDice SpawnNew()
    {
        var dice = spawner.Spawn();
        dice.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        dice.GetComponent<BoxCollider>().enabled = false;
        dice.transform.SetParent(transform);
        // dice.transform.SetPositionAndRotation(transform.position, transform.rotation);

        return dice;
    }

    // Function to dynamically increase the number of held dice
    public void UpdateMaxHeldDice(int newMaxHeldDice)
    {
        if (newMaxHeldDice > maxHeldDice)
        {
            int diceToAdd = newMaxHeldDice - maxHeldDice;

            for (int i = 0; i < diceToAdd; i++)
            {
                BaseDice dice = spawner.SpawnDice();
                dice.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                dice.GetComponent<BoxCollider>().enabled = false;
                dice.transform.SetParent(transform);
                dq.Add(dice);
            }

            maxHeldDice = newMaxHeldDice;
            RepositionDice();
            dq[dq.Count - 1].PlayFx(false, 0);
        }
    }
}
