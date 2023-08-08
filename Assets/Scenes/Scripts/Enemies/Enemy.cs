using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    public float health = 10f;
    public float maxHealth = 10f;

    public int reward = 5;

    bool waypoint_type;

    [Header("Unity Stuff")]
    public Image healthBar;

    private void Start() {
        if(Random.value < 0.5f) {
            waypoint_type = true;
            target = Waypoints.points[0];
        }
        else {
            waypoint_type = false;
            target = Waypoints.points2[0];
        }
    }

    public void AdjustSpeed(float multiplier)
    {
        speed *= multiplier;
    }

    public void TakeDamage(int amount) {
        
        health -= amount;
        healthBar.fillAmount = health / maxHealth;
        
        if(health <= 0f) {
            Destroy(gameObject);
        }
    }

    private void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.5f) {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint() {

        if(wavepointIndex >= Waypoints.points.Length - 1 && waypoint_type == true) {
            Destroy(gameObject);
            return;
        }
        else if (wavepointIndex >= Waypoints.points2.Length - 1 && waypoint_type == false)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        if (waypoint_type) {
            target = Waypoints.points[wavepointIndex];
        }
        else {
            target = Waypoints.points2[wavepointIndex];
        }
    }
}
