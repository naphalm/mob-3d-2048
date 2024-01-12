using System.Collections;
using UnityEngine;

public class DiceController : MonoBehaviour, IBullet
{
    public int value = 2;
    public int Value
    {
        get { return value; }
        set
        {
            this.value = value;
            builder.BuildDice(value);
        }
    }
    Rigidbody rb;
    BoxCollider bc;
    DiceBuilder builder;
    private void Awake()
    {
        builder = GetComponent<DiceBuilder>();
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
    }
    public void Shoot()
    {
        MakeActive();
        ApplyForce();
        StartCoroutine(Wait());
    }





    void MakeActive()
    {
        transform.SetParent(null);
        bc.enabled = true;
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
    }

    void ApplyForce()
    {
        rb.AddForce(transform.forward * BoardManager.Instance.forwardForce, ForceMode.VelocityChange);
    }

    IEnumerator Wait()
    {
        yield return null;
        EventRelay.Shooter.DiceShot.Invoke();
    }
}
