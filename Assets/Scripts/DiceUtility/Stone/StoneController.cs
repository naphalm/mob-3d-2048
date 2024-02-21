using TylerCode.SoundSystem;
using UnityEngine;

public class StoneController : BaseDice
{
    public static bool instance;
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

    [SerializeField] GameObject particlePrefab;
    S4SoundSource sound;
    private bool active = false;
    private int counter = 0;

    DiceBuilder builder;
    private void Awake()
    {
        instance = true;
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        builder = GetComponent<DiceBuilder>();
        sound = GetComponent<S4SoundSource>();

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
                DestroyStone();
            }
        }
    }

    public override void Shoot()
    {
        active = true;
        base.Shoot();
    }

    private void DestroyStone()
    {
        instance = false;
        Instantiate(particlePrefab, transform.position, Quaternion.identity);
        sound.PlaySound("Hit");
        Destroy(gameObject);
    }
}
