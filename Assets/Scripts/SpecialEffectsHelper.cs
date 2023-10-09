using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffectsHelper : MonoBehaviour
{
    public static SpecialEffectsHelper Instance;
    public ParticleSystem smokeEffect;
    public ParticleSystem fireEffect;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Несколько экземпляров SpecialEffectsHelper!");

        }
        Instance = this;
    }
    public void Explosion(Vector3 position)
    {
        instantiate(smokeEffect, position);
        instantiate(fireEffect, position);
    }
    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;
        Destroy(newParticleSystem, newParticleSystem.main.startLifetimeMultiplier);
        return newParticleSystem;
    }
}
