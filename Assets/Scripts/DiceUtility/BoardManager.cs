using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { get; private set; }


    [SerializeField]
    [Range(-10, 500)]
    public float forwardForce = 5f;

    [SerializeField]
    [Range(-10, 500)]
    public float upwardForce = 5f;
    [SerializeField] Shooter shooter;
    DiceQueue dq;

    private void Start()
    {
        EventRelay.Shooter.DiceShot.AddListener(OnDiceShot);
        EventRelay.Input.PointerUp.AddListener(OnPointerUp);

        dq = GetComponent<DiceQueue>();
        Reload();
    }

    static public void CombineDices(DiceController d1, DiceController d2)
    {
        // Check if either d1 or d2 is null
        // if (d1 == null || d2 == null)
        // {
        //     Debug.LogWarning("CombineDices called with null reference(s).");
        //     return;
        // }

        // if (d1.Value == d2.Value)
        var magnitude1 = d1.GetComponent<Rigidbody>().velocity.magnitude;
        var magnitude2 = d2.GetComponent<Rigidbody>().velocity.magnitude;

        if (magnitude1 > magnitude2)
        {
            // Destroy dice2
            Destroy(d2.gameObject);

            d1.Value *= 2;
            d1.ApplyCombineForce();
            EventRelay.Dice.Combination.Invoke(d1.Value * 2, d1.transform);
        }
        else
        {
            Destroy(d1.gameObject);

            d2.Value *= 2;
            d2.ApplyCombineForce();
            EventRelay.Dice.Combination.Invoke(d2.Value * 2, d2.transform);
        }
    }

    void OnDiceShot()
    {
        Reload();
    }

    void OnPointerUp()
    {
        shooter.Shoot();
    }

    void Reload()
    {
        if (shooter.Bullet == null)
        {
            var bullet = dq.GetNextDice();
            bullet.transform.SetParent(shooter.transform);
            bullet.transform.SetPositionAndRotation(shooter.transform.position, shooter.transform.rotation);
            shooter.Bullet = bullet;
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

}
