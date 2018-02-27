using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t3 : MonoBehaviour
{
    public GameObject ethan;
    private float x;
    private float y;
    private float z;
    private float dist;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void whereEthan()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        Debug.Log("ethan " + x + "/" + y + "/" + z);
    }
}
