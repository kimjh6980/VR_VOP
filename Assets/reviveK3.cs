using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reviveK3 : MonoBehaviour
{

    public Transform lv3k;

    private float dist;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        dist = lv3k.transform.position.y;
        if (dist < -5f)
        {
            Debug.Log("Kdist off");
            lv3k.GetComponent<Rigidbody>().useGravity = false;   // 중력 제거
            lv3k.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //camera.transform.localPosition = new Vector3(0, 0, 0);
            lv3k.transform.localPosition = new Vector3(-123.087f, 2.65f, -52.924f);
            lv3k.GetComponent<Rigidbody>().useGravity = true;   // 중력 제거
            dist = 0;
        }
        else
        {
            Debug.Log("K--------distance : " + dist);
        }
    }
}
