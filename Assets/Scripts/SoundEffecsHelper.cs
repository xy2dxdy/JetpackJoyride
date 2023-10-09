using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffecsHelper : MonoBehaviour
{
    public static SoundEffecsHelper Instance;
    public AudioClip explosionSound;
    public AudioClip playerShotSound;
    public AudioClip enemyShotSound;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Несколько экземпляров класса SoundEffectsHelper!");
        }
        Instance = this;
    }

    public void MakeExplosionSound()
    {
        MakeSound(explosionSound);
    }
    public void MakePlayerShotSound()
    {
        MakeSound(playerShotSound);
    }
    public void MakeEnemyShotSound()
    {
        MakeSound(enemyShotSound);
    }
    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
