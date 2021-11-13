using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Manager : MonoBehaviour
{
    private List<AudioSyncScale> scalers = new List<AudioSyncScale>();

    public float maxBias = 60;
    public float minBias = 1;

    float angle = 0f;
    float angleAdd = (Mathf.PI * 2) / 16f;

    public float raio;
    public Vector3 offSet;
    Transform parent;

    public bool editandoBias;
    void Start()
    {
        parent = GameObject.Find("Raios").transform;
        for (int i = 0; i < parent.childCount; i++)
        {
            Vector3 pos = new Vector3(Mathf.Sin(angle) * raio + offSet.x, Mathf.Cos(angle) * raio + offSet.y, 0f);
            parent.GetChild(i).gameObject.transform.position = pos;
            angle += angleAdd;
            scalers.Add(parent.GetChild(i).gameObject.GetComponent<AudioSyncScale>());
        }
        angle = 0f;
        for (int j = 0; j < scalers.Count; j++)
        {
            if (!editandoBias)
            {
                scalers[j].bias = Mathf.Lerp(minBias, maxBias, (float)(j + 1) / scalers.Count);
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Vector3 pos = new Vector3(Mathf.Sin(angle) * raio + offSet.x, Mathf.Cos(angle) * raio + offSet.y, 0f);
            parent.GetChild(i).gameObject.transform.position = pos;
            parent.GetChild(i).gameObject.transform.eulerAngles = new Vector3(0f, 0f, -angle * Mathf.Rad2Deg);
            angle += angleAdd;
        }

        angle = 0f;
    }
}
