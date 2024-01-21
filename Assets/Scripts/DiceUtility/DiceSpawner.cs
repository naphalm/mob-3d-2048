using UnityEngine;

public class DiceSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private DiceController dicePrefab; // 95% to spawn
    [SerializeField] private StoneController stonePrefab; // 5% to spawn
    public int percent = 50;

    public BaseDice Spawn()
    {
        // Generate a random number between 0 and 100 (inclusive)
        float randomPercentage = Random.Range(0f, 100f);

        // Check if the random number is less than or equal to the percentage chance for the dicePrefab
        if (randomPercentage <= percent)
        {
            // Instantiate the dicePrefab
            DiceController dice = Instantiate(dicePrefab, transform.position, Quaternion.identity);
            dice.GetComponent<Rigidbody>().useGravity = false;
            dice.GetComponent<BoxCollider>().enabled = false;

            dice.Value = (int)Mathf.Pow(2, Random.Range(1, 7));

            return dice;
        }
        else
        {
            // Instantiate the stonePrefab
            StoneController dice = Instantiate(stonePrefab, transform.position, Quaternion.identity);

            // Customize the stonePrefab as needed
            dice.GetComponent<Rigidbody>().useGravity = false;
            dice.GetComponent<BoxCollider>().enabled = false;
            dice.Value = 7;

            return dice;
        }
    }
}
