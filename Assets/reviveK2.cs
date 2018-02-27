using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reviveK2 : MonoBehaviour
{

    public Transform lv2k;

    private float dist;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        dist = lv2k.transform.position.y;
        if (dist < -5f)
        {
            Debug.Log("Kdist off");
            lv2k.GetComponent<Rigidbody>().useGravity = false;   // 중력 제거
            lv2k.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //camera.transform.localPosition = new Vector3(0, 0, 0);
            lv2k.transform.localPosition = new Vector3(-123.07f, 2.644f, -52.94f);
            lv2k.GetComponent<Rigidbody>().useGravity = true;   // 중력 제거
            dist = 0;
        }
        else
        {
            Debug.Log("K--------distance : " + dist);
        }
    }
}
