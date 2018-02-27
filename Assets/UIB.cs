using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIB : MonoBehaviour
{

    private SteamVR_TrackedObject trackedObj;
    // 추적할 오브젝트의 레퍼런스를 선언
    public GameObject laser;    // Laser prefab의 레퍼런스

    private Ray ray;
    private RaycastHit hit;
    public GameObject bullet;

    private GameObject CamRig;

    public GameObject setUI;

    private bool uion = false;

    private SteamVR_Controller.Device Controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }

    // Use this for initialization
    void Start()
    {
        CamRig = GameObject.Find("[CameraRig]");
        //CamRig.transform.position = new Vector3(-25.27f, 2.4f, -28.24f);
        CamRig.transform.rotation = Quaternion.Euler(0, 0, 0);
        // ui set visible
        setUI.SetActive(true);
        uion = true;
        Debug.Log("start-setActive : " + setUI);
    }

    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        uion = true;
        setUI.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward; // 발사방향

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            if (uion == true)
            {
                uion = false;
                setUI.SetActive(false);
                Debug.Log("uion : ----" + uion + "Change");
            }
            else
            {
                uion = true;
                setUI.SetActive(true);
                Debug.Log("uion : ----" + uion + "Change");
            }
        }

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("Trigger ====== uion : ----" + uion + "--------state");
            if (uion == true)
            {
                GameObject bul = Instantiate(bullet, this.transform.position + new Vector3(0f, 0.15f, 0f), this.transform.rotation);

                if (Physics.Raycast(ray, out hit, 100) && hit.collider.gameObject != GameObject.Find("Plane"))
                {
                    Debug.Log("Collider hit");
                    if (hit.collider.gameObject == GameObject.Find("lv1Button"))
                    {
                        CamRig.transform.position = new Vector3(-36.76f, 4.0f, -32.22f);
                        //CamRig.transform.position = new Vector3(-30.458f, 0.622f, 2.53f);
                        CamRig.transform.rotation = Quaternion.Euler(0, 90, 0);
                        Debug.Log("1");
                    }
                    else if (hit.collider.gameObject == GameObject.Find("lv2Button"))
                    {
                        CamRig.transform.position = new Vector3(-28.425f, 7.22f, -23.322f);
                        CamRig.transform.rotation = Quaternion.Euler(0, 90, 0);
                        Debug.Log("2");
                    }
                    else if (hit.collider.gameObject == GameObject.Find("lv3Button"))
                    {
                        CamRig.transform.position = new Vector3(-20.04f, 12.42f, -36.234f);
                        CamRig.transform.rotation = Quaternion.Euler(0, -90, 0);
                        Debug.Log("3");
                    }
                    else if (hit.collider.gameObject == GameObject.Find("ExitButton"))
                    {
                        SceneManager.LoadScene("start");
                        Debug.Log("out");
                    }
                    setUI.SetActive(false);
                    uion = false;

                }
                else
                {
                    // 물체집기
                }
                Destroy(bul, 2.0f); // 총알 객체 파괴.

            }
            
        }
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        { // 터치패드를 누르고 공 오브젝트와 충돌 하였을 때 

            laser.SetActive(true);
            if (Physics.Raycast(ray, out hit, 100) && hit.collider.gameObject != GameObject.Find("Plane"))
            {
                laser.transform.localScale = new Vector3(0.005f, 0.005f, hit.distance);
            }
        }
        else
        {
            laser.transform.localScale = new Vector3(0.005f, 0.005f, 1.0f);
            laser.SetActive(false);
        }
    }
}
