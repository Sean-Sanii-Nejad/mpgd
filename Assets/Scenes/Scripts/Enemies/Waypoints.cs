using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform waypoint_alt;
    public static Transform[] points;
    public static Transform[] points2;

    private void Awake() {

        points = new Transform[transform.childCount];
        for(int i = 0; i < points.Length; i++) {
            points[i] = transform.GetChild(i);
        }

        points2 = new Transform[10];
        for (int i = 0; i < points2.Length; i++)
        {
            points2[i] = waypoint_alt.GetChild(i);
        }
    }
}
