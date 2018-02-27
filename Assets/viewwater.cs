using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewwater : MonoBehaviour
{
    public GameObject water;
    public GameObject sub;
    public Camera cam;

    private float dist;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // y = 580.8
        dist = sub.transform.position.y;
        if (dist < 580.0f)
        {
            RenderSettings.fogColor = new Color(0, 0.5f, 0.7f, 0.6f);
            sub.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            sub.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
