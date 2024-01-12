using UnityEngine;

public class DiceSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private GameObject dicePrefab;

    public GameObject Spawn()
    {
        // Instantiate the prefab
        GameObject spawnedDice = Instantiate(dicePrefab, transform.position, Quaternion.identity);

        // Optionally, you can perform additional setup for the spawned dice here

        return spawnedDice;
    }
}
