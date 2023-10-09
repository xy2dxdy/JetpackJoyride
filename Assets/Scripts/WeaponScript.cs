using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private Transform shotPrefab;
    [SerializeField] private float shootingRate = 0.25f;
    private float shootCooldawn;
    public bool CanAttack
    {
        get { return shootCooldawn <= 0f; }
    }
    private void Start()
    {
        shootCooldawn = 0f;
    }
    private void Update()
    {
        if(shootCooldawn > 0)
            shootCooldawn -= Time.deltaTime;
    }

    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldawn = shootingRate;
            var shotTransform = Instantiate(shotPrefab);
            shotTransform.position = transform.position;
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                move.direction = this.transform.right;
            }

        }
    }
    
}
