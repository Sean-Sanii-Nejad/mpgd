using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour {
    
    
    private void OnTriggerEnter(Collider other){
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy")) {
            Debug.Log("slowed");
            Enemy enemyMovement = other.GetComponent<Enemy>();
            if (enemyMovement != null) {
                enemyMovement.AdjustSpeed(0.5f);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyMovement = other.GetComponent<Enemy>();
            if (enemyMovement != null)
            {
                enemyMovement.AdjustSpeed(2f);
            }
        }
    }
}
