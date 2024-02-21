using UnityEngine;

public class HeartController : BaseDice
{


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Dice"))
        {
            if (other.gameObject.GetComponent<DiceController>())
            {
                var dice = other.gameObject.GetComponent<DiceController>();
                EventRelay.Dice.Combination.Invoke(dice.Value, dice);
                dice.Value *= 2;
                dice.ApplyCombineForce();
                Destroy(gameObject);
            }
        }
    }
}
