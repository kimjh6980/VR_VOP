using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterin : MonoBehaviour {


    public GameObject water;
    public GameObject sub;
    public Camera cam;

    private float dist;
    private float setdist;
    private float G;
    private float B;
    private float Dense;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var move = 10 * Time.deltaTime;
        if(Input.GetKey("up"))
        {
            sub.transform.Translate(Vector3.up * move);
        }
        if (Input.GetKey("down"))
        {
            sub.transform.Translate(Vector3.down * move);
        }

        dist = sub.transform.position.y;
        if(dist > 580.0f)
        {
            RenderSettings.fog = false;
        }

        if (dist < 580.0f)
        {
            
            RenderSettings.fog = true;  // 안개모드 활성화

            //RenderSettings.fogColor = new Color(0, 0.8f, 0.9f, 0.9f);   // 색 지정
            //RenderSettings.fogDensity = 0.0025f;    // 투영도 지정

            //RenderSettings.fogColor = new Color(0, 0.1f, 0.1f, 0.9f);   // 색 지정
            //RenderSettings.fogDensity = 0.1f;    // 투영도 지정

            RenderSettings.fogStartDistance = 0.0f; // 안개 시작 거리
            sub.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);  // 중력가속도 0
            sub.GetComponent<Rigidbody>().useGravity = false;   // 중력 제거
            
            //grip 누르면 내려가고 trigger누르면 올라가기
            setdist = dist / 10;
            G = setdist * 0.009f;
            Dense = 2 / dist;
            RenderSettings.fogColor = new Color(0, G, G, 0.9f);   // 색 지정
            RenderSettings.fogDensity = Dense;    // 투영도 지정
            Debug.Log("G : " + G + "/ B : " + B + "/Dense : " + Dense);
            

        }
    }
}
 