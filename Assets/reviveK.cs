using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reviveK : MonoBehaviour {

    public Transform lv1k;

    private float dist;

    // Use this for initialization
    void Start () {
        
    }
	
    void Update()
    {
        dist = lv1k.transform.position.y;
        if (dist < -5f)
        {
            Debug.Log("Kdist off");
            lv1k.GetComponent<Rigidbody>().useGravity = false;   // 중력 제거
            lv1k.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //camera.transform.localPosition = new Vector3(0, 0, 0);
            lv1k.transform.localPosition = new Vector3(5.76f, 3.05f, 34.69f);
            lv1k.GetComponent<Rigidbody>().useGravity = true;   // 중력 제거
            dist = 0;
        }
        else
        {
            Debug.Log("K--------distance : " + dist);
        }
    }
}
