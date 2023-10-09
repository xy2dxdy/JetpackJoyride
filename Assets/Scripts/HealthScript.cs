using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private int hp = 1;
    [SerializeField] private bool isEnemy = true;

    public void Damage(int damageCount)
    {
        hp -= damageCount;
        if (hp <= 0)
        {
            SpecialEffectsHelper.Instance.Explosion(transform.position);
            SoundEffecsHelper.Instance.MakeExplosionSound();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        ShotScript shoot = otherCollider.gameObject.GetComponent<ShotScript>();
        if(shoot != null) 
        {
            if (shoot.isEnemyShot != isEnemy)
            {
                Damage(shoot.damage);
                Destroy(shoot.gameObject);
            }
        }
    }
    public int GetHP() { return hp; }
}
