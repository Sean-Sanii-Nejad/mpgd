using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    public TurretBlueprint standardTurret;
    public TurretBlueprint machineTurret;
    public TurretBlueprint slowTurret;

    void Start(){
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret(){
        Debug.Log("Standard");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectLaserTurret()
    {
        Debug.Log("Machine");
        buildManager.SelectTurretToBuild(machineTurret);
    }

    public void SelectSlowTurret()
    {
        buildManager.SelectTurretToBuild(slowTurret);
    }

}
