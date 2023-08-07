using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    void Start(){
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret(){
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseAOETurret()
    {
        buildManager.SetTurretToBuild(buildManager.aoeTurretPrefab);
    }

    public void PurchaseLaserTurret()
    {
        buildManager.SetTurretToBuild(buildManager.laserTurretPrefab);
    }

    public void PurchaseDefenceTurret()
    {
        buildManager.SetTurretToBuild(buildManager.defenceTurretPrefab);
    }

    public void PurchaseSlowTurret()
    {
        buildManager.SetTurretToBuild(buildManager.slowTurretPrefab);
    }

}
