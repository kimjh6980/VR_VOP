using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class High_setL : MonoBehaviour {

    // GameObject로 쓰긴 했는데 인터넷에서는 Transform이였음
    public GameObject plv1;
    public GameObject plv2;
    public GameObject plv3;
    public GameObject lsplv;
    public GameObject setplv;

    private SteamVR_TrackedObject trackedObj;
    // 2
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

    }

    // Update is called once per frame
    void Update () {
        if (Controller.GetAxis() != Vector2.zero)
        {
            Debug.Log(setplv.name + " //");
            
            Setplv(setplv);
            lsplv.GetComponent<MeshRenderer>().material.color = Color.white;
            setplv.GetComponent<MeshRenderer>().material.color = Color.yellow;
            Debug.Log(gameObject.name + Controller.GetAxis());


        }

        // 2
        if (Controller.GetHairTriggerDown())
        {
            
        }

        // 3
        if (Controller.GetHairTriggerUp())
        {
            Debug.Log(gameObject.name + " Trigger Release");
        }

        // 4
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Press");
        }

        // 5
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Release");
        }

    }

    void Setplv(GameObject gb)
    {
        if(gb = plv1) {
            lsplv = plv1;
            setplv = plv2; }
        else if(gb = plv2) {
            lsplv = plv2;
            setplv = plv3; }
        else if(gb = plv3) {
            lsplv = plv3;
            setplv = plv1; }
    }
}
