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

        // EventRelay.Board.Bonus.AddListener(OnCombine);
    }

    public void Play(bool withSound, int nrSound)
    {
        fx.Play();
        if (withSound)
        {
            var ss = "Combine1";
            if (nrSound == 2)
            {
                ss = "Combine2";
            }
            else if (nrSound > 2)
            {
                ss = "Combine3";
            }

            sound.PlaySound(ss);
        }
    }

    /*
    if (counter == 2)
        {
            BoardManager.Instance.fxPitch = secondPitch;
        }
        else if (counter > 2)
        {
            BoardManager.Instance.fxPitch = thirdPitch;
        }
    */




}
