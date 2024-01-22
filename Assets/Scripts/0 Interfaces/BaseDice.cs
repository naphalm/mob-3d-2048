using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class BaseDice : MonoBehaviour, IBullet
{
    protected Rigidbody rb;
    protected BoxCollider bc;

    public virtual void Shoot()
    {
        transform.SetParent(null);
        MakeActive();
        ApplyShootForce();
        StartCoroutine(Wait());
    }

    public virtual void MakeActive()
    {
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

    public virtual void RemoveDice()
    {
        Destroy(gameObject);
    }

    public virtual void PlayFx(bool activeSound)
    {

    }
}
