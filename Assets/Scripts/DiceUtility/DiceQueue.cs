using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiceQueue : MonoBehaviour
{
    private DiceSpawner spawner;
    public List<DiceController> dq = new List<DiceController>();
    public int maxHeldDice = 5; // Set your desired maximum number of held dice here


    private void Awake()
    {
        spawner = GetComponent<DiceSpawner>();
        InitializeDiceQueue();
    }

    public DiceController GetNextDice()
    {

        dq.Add(SpawnNew());

        DiceController oldestDice = dq[0];
        dq.RemoveAt(0);
        RepositionDice();

        return oldestDice;
    }

    private void InitializeDiceQueue()
    {
        for (int i = 0; i < maxHeldDice; i++)
        {
            DiceController dice = SpawnNew();
            dq.Add(dice);
        }
        RepositionDice();
    }

    void RepositionDice()
    {
        for (int i = 0; i < dq.Count; i++)
        {
            dq[i].transform.SetLocalPositionAndRotation(new Vector3(i, -i, 0), transform.rotation);
        }
    }

    DiceController SpawnNew()
    {
        var dice = spawner.Spawn();
        dice.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        dice.GetComponent<BoxCollider>().enabled = false;
        dice.transform.SetParent(transform);
        // dice.transform.SetPositionAndRotation(transform.position, transform.rotation);

        return dice;
    }
}
