using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BuildManager : MonoBehaviour { 
    
    private TurretBlueprint turretToBuild;

    public static BuildManager instance;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    private void Awake() {
        instance = this;
    }

    private void Start() {
    }

    public void SelectTurretToBuild(TurretBlueprint turret) {
        turretToBuild = turret; 
    }

    public void BuildTurretOn(Node node) {

        if(PlayerStats.Money < turretToBuild.cost) {
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }
}
