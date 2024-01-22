using System.Collections;
using TylerCode.SoundSystem;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public IBullet Bullet { get; set; }
    public float cooldownTime = 0.1f; // Set your desired cooldown time in seconds
    private bool isOnCooldown = false;
    private bool active = true;

    S4SoundSource sfx;

    private void Awake()
    {
        sfx = GetComponent<S4SoundSource>();
    }

    private void Start()
    {
        EventRelay.GameManager.Death.AddListener(OnLevelEnd);
        EventRelay.GameManager.ContinueEnded.AddListener(OnContinueEnded);
    }

    public void Shoot()
    {
        if (active)
        {
            if (!isOnCooldown && Bullet != null)
            {
                sfx.PlaySound("Shoot");
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

    }

    private IEnumerator CooldownCoroutine()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }

    void OnLevelEnd()
    {
        active = false;
    }

    void OnContinueEnded()
    {
        active = true;
    }


}
