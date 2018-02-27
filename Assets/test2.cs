using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class test2 : MonoBehaviour {

    private GameObject CamRig;
    private GameObject ethan;
    //Vector3 lv1m = new Vector3(1.192, 1.4, -1.1);
    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        CamRig = GameObject.Find("[CameraRig]");
        //CamRig.transform.position = new Vector3(-25.27f, 2.4f, -28.24f);
        CamRig.transform.rotation = Quaternion.Euler(0, 0, 0);
        ethan.transform.localPosition = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void lv1move()
    {
        CamRig.transform.position = new Vector3(-36.76f, 4.0f, -32.22f);
        //CamRig.transform.position = new Vector3(-30.458f, 0.622f, 2.53f);
        CamRig.transform.rotation = Quaternion.Euler(0, 90, 0);
    }
    public void lv2move()
    {
        CamRig.transform.position = new Vector3(-28.425f, 7.22f, -23.322f);
        CamRig.transform.rotation = Quaternion.Euler(0, 90, 0);
    }
    public void lv3move()
    {
        CamRig.transform.position = new Vector3(-20.04f, 12.42f, -36.234f);
        CamRig.transform.rotation = Quaternion.Euler(0, -90, 0);
    }
}
