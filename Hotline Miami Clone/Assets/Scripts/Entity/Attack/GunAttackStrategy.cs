using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.interfaces;
using Unity.VisualScripting;

public class GunAttackStrategy : MonoBehaviour, IAttackStrategy
{
    private Weapon currentWeapon;
    private float lastAttackTime;
    private Transform firePoint;
    private bool isAutomaticAttackEnabled = false;

    

    public void EnableAutomaticAttack()
    {
        isAutomaticAttackEnabled = true;
    }

    public void DisableAutomaticAttack()
    {
        isAutomaticAttackEnabled = false;
    }

    public void Attack(Transform firePoint, Weapon currentWeapon)
    {
        this.currentWeapon = currentWeapon;
        this.firePoint = firePoint;

        if (currentWeapon.isGun)
        {
            if (currentWeapon.numOfAttacks == 0)
            {
                Debug.Log("No attacks left.");
                return; // Нельзя атаковать, если атак нет
            }

            if (isAutomaticAttackEnabled)
            {
                AutomaticAttack();
            }
            else
            {
                SemiAutomaticAttack();
            }
        }
        else
        {
            throw new System.Exception("The current weapon is not a gun.");
        }
    }

    private void Update()
    {
        if (isAutomaticAttackEnabled)
        {
            AutomaticAttack();
        }
    }

    private void AutomaticAttack()
    {
        if (Time.time - lastAttackTime >= 1f / currentWeapon.attackRate)
        {
            if (currentWeapon.numOfAttacks > 0)
            {
                lastAttackTime = Time.time;
                ShootBullet();
                if (currentWeapon.numOfAttacks > 0)
                {
                    currentWeapon.numOfAttacks--; // Уменьшаем количество атак
                }
            }
        }
    }

    private void SemiAutomaticAttack()
    {
        if (Time.time - lastAttackTime >= 1f / currentWeapon.attackRate)
        {
            if (currentWeapon.numOfAttacks > 0)
            {
                lastAttackTime = Time.time;
                ShootBullet();
                if (currentWeapon.numOfAttacks > 0)
                {
                    currentWeapon.numOfAttacks--; // Уменьшаем количество атак
                }
            }
        }
    }

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(currentWeapon.bulletPrefabObject, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * currentWeapon.bulletForce, ForceMode2D.Impulse);
    }
}
