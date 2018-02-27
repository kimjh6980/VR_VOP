using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LaserPointer : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;

	public GameObject laserPrefab;
	private GameObject laser;
	private Transform laserTransform;
	private Vector3 hitPoint;

	//충돌 오브젝트 각각
	public GameObject interview;
	public GameObject undersea;
	public GameObject high;

    //정보창 알림 오브젝트
    public GameObject infoUI;
    public Text SetInfo;
    public GameObject OB;
    public GameObject NB;

	private string setContent = null;

	private SteamVR_Controller.Device Controller {
		get {
			return SteamVR_Controller.Input ((int)trackedObj.index);
		}
	}

	void Awake()	{
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
        infoUI.SetActive(false);

    }

    private void ShowLaser(RaycastHit hit)
    {
        // 1
        laser.SetActive(true);
        // 2
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);
        // 3
        laserTransform.LookAt(hitPoint);
        // 4
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
       laserTransform.localScale.y, hit.distance);
    }

    void Update()	{
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            RaycastHit hit;

            // 2
            if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
            }

            
        }
        else if (Controller.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            SceneManager.LoadScene("1");
            //               sceneChange("high");
        }
        else // 3
        {
            laser.SetActive(false);
        }
        /*
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            // 여기 이제 충돌했을 때
            if (hit.collider.gameObject == interview)
            {

//                sceneChange("interview");
            }
            else if (hit.collider.gameObject == undersea)
            {
 //               sceneChange("undersea");
            }
            else if (hit.collider.gameObject == high)
            {
                SceneManager.LoadScene("1");
 //               sceneChange("high");
            }
        }
            /*
            RaycastHit hit;

            if(Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100))	{
                hitPoint = hit.point;
                ShowLaser(hit);
            }

            if(Controller.GetPress(SteamVR_Controller.ButtonMask.Trigger))	{

                // 여기 이제 충돌했을 때
                if (hit.collider.gameObject == interview)
                {
                    sceneChange("interview");
                }
                else if (hit.collider.gameObject == undersea)
                {
                    sceneChange("undersea");
                }
                else if (hit.collider.gameObject == high)
                {
                    sceneChange("high");
                }

                if (hit.collider.gameObject == OB)
                {
                    // 화면바꾸기
                }
                else if (hit.collider.gameObject == NB)
                {
                    infoUI.SetActive(false);
                }
            }*/
            /*
            if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                RaycastHit hit;

                // 2
                if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100))
                {
                    hitPoint = hit.point;
                    ShowLaser(hit);
                }
            }
            else // 3
            {
                laser.SetActive(false);
            }*/
        }

	void Start()	{
		laser = Instantiate(laserPrefab);
		laserTransform = laser.transform;
    }
    
    void sceneChange(string select)
    {
        if (select == "interview")
        {
            SetInfo.text = "면접공포증";
        }
        else if (select == "undersea")
        {
            SetInfo.text = "심해공포증";
        }
        else if (select == "high")
        {
            SetInfo.text = "고소공포증";
        }
        infoUI.SetActive(true);
        //GameObject.Find("information").transform.FindChild("infoUI").gameObject.SetActive(true);
    }
    
    public void ChangeGameScene()
    {
        SceneManager.LoadScene("1");
    }
}
