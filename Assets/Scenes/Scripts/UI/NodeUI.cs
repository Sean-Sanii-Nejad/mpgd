using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;

    public void SetTarget(Node _target)
    {
        ui.SetActive(true);
        target = _target;

        transform.position = target.GetBuildPosition() + new Vector3(0,1f,0);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

}
