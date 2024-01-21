using UnityEngine;

public class StoneController : BaseDice
{
    public int value = 8;
    public int Value
    {
        get { return value; }
        set
        {
            this.value = value;
            builder.BuildDice(value);
        }
    }
    private bool active = false;
    private int counter = 0;

    DiceBuilder builder;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        builder = GetComponent<DiceBuilder>();

        EventRelay.Shooter.DiceShot.AddListener(OnDiceShot);
    }

    void OnDiceShot()
    {
        if (active == true)
        {
            if (++counter >= 2)
            {
                Value--;
            }
            if (Value == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public override void Shoot()
    {
        active = true;
        base.Shoot();
    }
}
