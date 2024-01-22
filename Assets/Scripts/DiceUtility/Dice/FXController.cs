using System.Collections;
using System.Collections.Generic;
using TylerCode.SoundSystem;
using UnityEngine;
using UnityEngine.Assertions;

public class FXController : MonoBehaviour
{
    ParticleSystem fx;
    private S4SoundSource sound;



    private void Awake()
    {
        fx = GetComponent<ParticleSystem>();
        Assert.IsNotNull(fx, "ParticleSystem not found!");
        fx.Stop();
        sound = GetComponent<S4SoundSource>();
        Assert.IsNotNull(fx, "S4Sound not found!");
    }

    public void Play(bool withSound)
    {
        fx.Play();
        if (withSound)
        {
            sound.PlaySoundWithSetPitch("Combine", BoardManager.Instance.fxPitch);
        }
    }


}
