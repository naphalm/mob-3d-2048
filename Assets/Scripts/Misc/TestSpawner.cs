using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    [SerializeField] private DiceController dicePrefab; // 95% to spawn
    public int nr = 30;
    public List<BaseDice> dq = new();

    private void Start()
    {
        SpawnAll();
    }

    public BaseDice Spawn(int value)
    {
        // Instantiate the dicePrefab
        DiceController dice = Instantiate(dicePrefab, transform.position, Quaternion.identity);
        dice.GetComponent<Rigidbody>().useGravity = false;
        dice.GetComponent<BoxCollider>().enabled = false;
        dice.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        dice.transform.SetParent(transform);

        dice.Value = value;

        return dice;
    }

    public void SpawnAll()
    {
        for (int i = 1; i <= nr; i++)
        {
            dq.Add(Spawn((int)Mathf.Pow(2, i)));
        }

        PositionDice();
    }

    void PositionDice()
    {
        int dicePerRow = 10;
        float spacingX = 1.0f; // Adjust this value for the spacing between dice in the same row
        float spacingZ = 1.0f; // Adjust this value for the spacing between rows

        for (int i = 0; i < dq.Count; i++)
        {
            int row = i / dicePerRow;
            int col = i % dicePerRow;

            float posX = col * spacingX;
            float posZ = row * spacingZ;

            dq[i].transform.localPosition = new Vector3(posX, 0, -posZ);
        }
    }
}
