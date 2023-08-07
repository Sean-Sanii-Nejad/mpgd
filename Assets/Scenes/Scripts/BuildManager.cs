using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour { 
    
    private GameObject turretToBuild;
    
    public GameObject standardTurretPrefab;
    public GameObject aoeTurretPrefab;
    public GameObject laserTurretPrefab;
    public GameObject defenceTurretPrefab;
    public GameObject slowTurretPrefab;

    public static BuildManager instance;

    private void Awake() {
        instance = this;
    }

    private void Start() {
    }

    public void SetTurretToBuild(GameObject turret) {
        turretToBuild = turret; 
    }


    public GameObject GetTurretToBuild() {
        return turretToBuild;
    }
}
