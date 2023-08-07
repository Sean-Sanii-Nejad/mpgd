using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret;
    
    private Renderer rend;
    private Color startColor;

    private Vector3 positionOffset = new Vector3(0,0.5f,0);

    BuildManager buildManager;

    void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown() {
        if (buildManager.GetTurretToBuild() == null) return;

        if(turret != null) {
            Debug.Log("Can't Build");
            return;
        }
        if(PlayerStats.Money > 50) {
            PlayerStats.Money -= 50;
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
        }
        
    }

    void OnMouseEnter() {
        if (buildManager.GetTurretToBuild() == null) return;
        rend.material.color = hoverColor;
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }

}
