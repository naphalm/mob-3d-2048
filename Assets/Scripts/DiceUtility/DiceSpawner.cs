using UnityEngine;

public class DiceSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private DiceController dicePrefab; // 95% to spawn
    [SerializeField] private StoneController stonePrefab; // 2.5% to spawn
    [SerializeField] private HeartController heartPrefab; // 2.5% to spawn
    public int percent = 95;

    public BaseDice Spawn()
    {
        // Generate a random number between 0 and 100 (inclusive)
        float randomPercentage = Random.Range(0f, 100f);

        // Check if the random number is less than or equal to the percentage chance for the dicePrefab
        if (randomPercentage <= percent)
        {
            return SpawnDice();
        }
        else
        {
            randomPercentage = Random.Range(0f, 100f);
            if (randomPercentage <= 50f && StoneController.instance == false)
            {
                return SpawnStone();
            }
            else
            {
                return SpawnHeart(); // change into SpawnHear
            }

        }
    }

    public BaseDice SpawnDice()
    {
        // Instantiate the dicePrefab
        DiceController dice = Instantiate(dicePrefab, transform.position, Quaternion.identity);
        dice.GetComponent<Rigidbody>().useGravity = false;
        dice.GetComponent<BoxCollider>().enabled = false;

        dice.Value = (int)Mathf.Pow(2, Random.Range(1, BoardManager.Instance.maxPow2));

        return dice;
    }

    BaseDice SpawnStone()
    {
        StoneController dice = Instantiate(stonePrefab, transform.position, Quaternion.identity);

        // Customize the stonePrefab as needed
        dice.GetComponent<Rigidbody>().useGravity = false;
        dice.GetComponent<BoxCollider>().enabled = false;
        dice.Value = 7;

        return dice;
    }

    BaseDice SpawnHeart()
    {
        HeartController dice = Instantiate(heartPrefab, transform.position, Quaternion.identity);

        // Customize the stonePrefab as needed
        dice.GetComponent<Rigidbody>().useGravity = false;
        dice.GetComponent<BoxCollider>().enabled = false;
        // dice.transform.rotation = new Quaternion(-90f, 0f, 0f, 0);

        return dice;
    }
}
