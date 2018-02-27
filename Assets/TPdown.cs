using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPdown : MonoBehaviour
{
    public GameObject ethan;
    public GameObject camera;
    private float dist;

    // Use this for initialization
    void Start()
    {
        camera.transform.position = GameObject.Find("[CameraRig].Camera(head)").transform.position;
        ethan.transform.position = GameObject.Find("[CameraRig].Camera(head).ThridPersonController").transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        dist = ethan.transform.position.y;
        if (dist < -5f)
        {
            Debug.Log("dist off");
            ethan.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //camera.transform.localPosition = new Vector3(0, 0, 0);
            ethan.transform.localPosition = new Vector3(0, 0, 0);
            dist = 0;
        }
        else
        {
            Debug.Log("distance : " + dist);
        }
    }
}
