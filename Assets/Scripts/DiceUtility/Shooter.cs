using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public IBullet Bullet { get; set; }
    public float cooldownTime = 0.1f; // Set your desired cooldown time in seconds
    private bool isOnCooldown = false;

    public void Shoot()
    {
        if (!isOnCooldown && Bullet != null)
        {
            Bullet.Shoot();
            Bullet = null;
            StartCoroutine(CooldownCoroutine());
        }
        else if (isOnCooldown)
        {
            // Handle the case when the shooter is on cooldown
            Debug.Log("Shooter is on cooldown. Cannot shoot yet.");
        }
        else
        {
            EventRelay.Shooter.EmptyShooter.Invoke();
        }
    }

    private IEnumerator CooldownCoroutine()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }
}
