using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour { 
    
    private GameObject turretToBuild;
    public static BuildManager instance;
    public GameObject standardTurretPrefab;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        turretToBuild = standardTurretPrefab;
    }

    public GameObject GetTurretToBuild() {
        return turretToBuild;
    }
}
