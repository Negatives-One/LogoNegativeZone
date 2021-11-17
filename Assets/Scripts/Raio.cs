using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raio : MonoBehaviour
{
    public float distance;
    public float offSetDistance;
    public float plusDistance = 0f;
    public float angle;
    public Vector3 offSet;

    public GameObject middle;

    public float startDist;

    private void Start()
    {
        startDist = distance;
    }
    void Update()
    {
        Vector3 pos = new Vector3(Mathf.Sin(angle) * (distance + plusDistance) + offSet.x, Mathf.Cos(angle) * (distance + plusDistance) + offSet.y, 0f);
        transform.position = pos;
        plusDistance = (middle.transform.localScale.x - 1f) * offSetDistance;
    }
}
