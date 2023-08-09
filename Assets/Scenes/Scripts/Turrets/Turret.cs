using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;

using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Unity Requirements")]
    public Transform target;
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;


    public string enemyTag = "Enemy";

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    void Start() {
        InvokeRepeating("UpdateTarget", 0f, 1f);
    }

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies) {

            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range) {
            target = nearestEnemy.transform;
        }
    }

    void Update() {
        if(target == null) { return; }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotatation = Quaternion.LookRotation(dir);

        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotatation, Time.deltaTime * 7.5f).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown <= 0f) {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, range);
        
    }

    private void Shoot() {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null) {
            bullet.Seek(target);
        }
    }
}
