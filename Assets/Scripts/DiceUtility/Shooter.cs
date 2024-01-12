using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public IBullet Bullet { get; set; }

    public void Shoot()
    {
        if (Bullet != null)
        {
            Bullet.Shoot();
            Bullet = null;
        }
        else
        {
            EventRelay.Shooter.EmptyShooter.Invoke();
        }
    }
}
