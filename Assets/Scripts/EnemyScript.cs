using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private WeaponScript[] weapons;
    private bool hasSpawn;
    private MoveScript moveScript;

    private void Awake()
    {
        weapons = GetComponentsInChildren<WeaponScript>();
        moveScript = GetComponent<MoveScript>();
    }
    private void Start()
    {
        hasSpawn = false;
        GetComponent<Collider2D>().enabled = false;
        moveScript.enabled = false;
        foreach (WeaponScript weapon in weapons) 
        {
            weapon.enabled = false;
        }
    }
    private void Update()
    {
        if (hasSpawn == false)
        {
            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            foreach (WeaponScript weapon in weapons)
            {
                if (weapon != null && weapon.CanAttack)
                {
                    weapon.Attack(true);
                    SoundEffecsHelper.Instance.MakeEnemyShotSound();
                }
            }
            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
        
    }
    private void Spawn()
    {
        hasSpawn = true;
        GetComponent<Collider2D>().enabled = true;
        moveScript.enabled = true;
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = true;
        }
    }
}
