using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

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
            Debug.Log("Can't Build");
            return;
        }
        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter() {
        if (!buildManager.CanBuild) return;
        rend.material.color = hoverColor;
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }

}
