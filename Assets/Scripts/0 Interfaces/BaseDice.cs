using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class BaseDice : MonoBehaviour, IBullet
{
    protected Rigidbody rb;
    protected BoxCollider bc;

    public virtual void Shoot()
    {
        MakeActive();
        ApplyShootForce();
        StartCoroutine(Wait());
    }

    protected virtual void MakeActive()
    {
        transform.SetParent(null);
        bc.enabled = true;
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
    }

    protected void ApplyShootForce()
    {
        rb.AddForce(transform.forward * BoardManager.Instance.forwardForce, ForceMode.VelocityChange);
    }

    protected IEnumerator Wait()
    {
        yield return null;
        EventRelay.Shooter.DiceShot.Invoke();
    }
}
