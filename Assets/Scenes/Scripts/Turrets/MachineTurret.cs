using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTurret : MonoBehaviour {
    [Header("Unity Requirements")]
    public Transform target;
    public Transform partToRotate;
    public Transform firePoint;
    public string enemyTag = "Enemy";

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public ParticleSystem shootEffect;

    [Header("Attributes")]
    public float range = 15f;

    void Start() {
        InvokeRepeating("UpdateTarget", 0f, 1f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) {
            target = nearestEnemy.transform;
        } else {
            target = null;
        }
    }

    void Update() {
        if (target == null) {
            if (lineRenderer.enabled) {
                Debug.Log("turn off");
                lineRenderer.enabled = false;
                impactEffect.Stop();
                shootEffect.Stop();
            }
            return; 
        }
        LockOnTarget();
        Shoot();
    }

    private void LockOnTarget() {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotatation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotatation, Time.deltaTime * 7.5f).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Shoot() {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            shootEffect.Play();
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        impactEffect.transform.position = target.position;
    }
}
