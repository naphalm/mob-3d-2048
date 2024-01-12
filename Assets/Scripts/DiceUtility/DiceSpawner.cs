using UnityEngine;

public class DiceSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private DiceController dicePrefab;

    public DiceController Spawn()
    {
        // Instantiate the prefab
        DiceController dice = Instantiate(dicePrefab, transform.position, Quaternion.identity);
        dice.GetComponent<Rigidbody>().useGravity = false;
        dice.GetComponent<BoxCollider>().enabled = false;

        dice.Value = (int)Mathf.Pow(2, Random.Range(1, 7));

        return dice;
    }
}
