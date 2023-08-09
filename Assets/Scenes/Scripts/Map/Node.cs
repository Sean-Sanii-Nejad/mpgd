using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color hoverColorNoMoney;

    public GameObject turret;
    
    private Renderer rend;
    private Color startColor;

    private Vector3 positionOffset = new Vector3(0,0.5f,0);

    BuildManager buildManager;


    public Vector3 GetBuildPosition(){
        return transform.position + positionOffset;
    }


    void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown() {
        if (!buildManager.CanBuild) return;

        if (turret != null) {
            buildManager.SelectNode(this);
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter() {

        if (!buildManager.CanBuild) return;

        if(buildManager.HasMoney) {
            rend.material.color = hoverColor;
        }
        else {
            rend.material.color = hoverColorNoMoney;
        }

        
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }

    public void UpgradeTurret()
    {
        //if (PlayerStats.Money < upg.cost)
        //{
        //    return;
        //}

        //PlayerStats.Money -= turretToBuild.cost;

        //GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        //node.turret = turret;

        //GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        //Destroy(effect, 2f);
    }

}
