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
