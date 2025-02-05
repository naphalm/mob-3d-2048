using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

public class DiceController : BaseDice
{
    public int value = 2;
    public int Value
    {
        get { return value; }
        set
        {
            this.value = value;
            builder.BuildDice(value);
            EventRelay.Dice.DiceValueChanged.Invoke(value);
        }
    }
    DiceBuilder builder;
    FXController fx;

    private void Awake()
    {
        fx = GetComponentInChildren<FXController>();
        Assert.IsNotNull(fx);
        // fx.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        builder = GetComponent<DiceBuilder>();
    }

    public void ApplyCombineForce()
    {
        rb.velocity = new Vector3(0, 0, 0);
        rb.AddForce(Vector3.up * BoardManager.Instance.upwardForce, ForceMode.Impulse); // Apply upward force in world space
        rb.AddForce(Vector3.forward * BoardManager.Instance.forwardForce / 3f, ForceMode.Impulse); // Apply forward force in world space
        // rb.AddForce(-Vector3.up * BoardManager.Instance.upwardForce / 1.1f, ForceMode.VelocityChange); // Apply downward force in world space
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Dice"))
        {
            var d2 = other.gameObject.GetComponent<DiceController>();
            if (d2 != null && d2.Value == Value)
            {
                BoardManager.CombineDices(this, d2);
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Dice"))
        {
            var d2 = other.gameObject.GetComponent<DiceController>();
            if (d2 != null && d2.Value == Value)
            {
                BoardManager.CombineDices(d2, this);
            }
        }
    }

    public override void PlayFx(bool soundOn, int nrSound)
    {
        fx.Play(soundOn, nrSound);
    }
}
