using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class waterC : MonoBehaviour
{

    private SteamVR_TrackedObject trackedObj;
    // 추적할 오브젝트의 레퍼런스를 선언
    public GameObject laser;    // Laser prefab의 레퍼런스
    public GameObject setUI;
    public GameObject Wall;

    private Ray ray;
    private RaycastHit hit;
    public GameObject bullet;

    private GameObject CamRig;
    private GameObject ethan;
    public GameObject eye;

    private bool uion = true;
    private bool going = false;

    private float locatex;
    private float locatey;
    private float locatez;

    private float rotatex;
    private float rotatey;
    private float rotatez;



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
        uion = false;
        setUI.SetActive(false);
        going = false;
        Debug.Log("Go : " + going + "///// uion " + uion);
    }

    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        uion = false;
        setUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        var move = 10 * Time.deltaTime;
        Vector3 lookDirection;

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            if (uion == true)
            {
                uion = false;
                setUI.SetActive(false);
                Debug.Log("UION : " + uion);
            }
            else
            {
                uion = true;
                setUI.SetActive(true);
                Debug.Log("UION : " + uion);
            }
        }

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            ray.origin = this.transform.position;
            ray.direction = this.transform.forward; // 발사방향
            GameObject bul = Instantiate(bullet, this.transform.position + new Vector3(0f, 0.15f, 0f), this.transform.rotation);
            Debug.Log("Trigger ");
            if (uion == true)
            {
                Debug.Log("UION is true so");

                if (Physics.Raycast(ray, out hit, 100) && hit.collider.gameObject != GameObject.Find("Plane"))
                {
                    if (hit.collider.gameObject == GameObject.Find("yes"))
                    {
                        SceneManager.LoadScene("start");
                    }
                    else if (hit.collider.gameObject == GameObject.Find("no"))
                    {
                        uion = false;
                        setUI.SetActive(false);
                    }
                    

                }
                else
                {
                    // 물체집기
                }

            }
            else
            {
                laser.transform.localScale = new Vector3(0.005f, 0.005f, 1.0f);
                laser.SetActive(false);
                // 여기서는 물체집기
            }
            Destroy(bul, 2.0f); // 총알 객체 파괴.
        }

        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        { // 터치패드를 누르고 오브젝트와 충돌 하였을 때 
            Debug.Log("TouchPad");

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

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log("GRIP");
            if (going == false)
            {
                going = true;
                Wall.SetActive(false);
                Debug.Log("GRIP goint f-t");

            }
            else
            {


                going = false;
                Debug.Log("GRIP goint t-f");

                Wall.SetActive(true);
                CamRig.transform.localPosition = new Vector3(97.6f, 132.7f, 380.79f);
            }
        }

        if (Controller.GetAxis() != Vector2.zero)
        {
            /*
            if (going == true) {
                if (Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y > 0.5f)
                {
                    Debug.Log(trackedObj.index + " Movement Dpad Up");

                    CamRig.transform.Translate(Vector3.forward * Time.deltaTime * 6);
                }

                if (Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y < -0.5f)
                {
                    Debug.Log(trackedObj.index + " Movement Dpad Down");
                    CamRig.transform.Translate(Vector3.back * Time.deltaTime * 6);
                }

                if (Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x > 0.5f)
                {
                    Debug.Log(trackedObj.index + " Movement Dpad Right");
                    CamRig.transform.Translate(Vector3.right * Time.deltaTime * 6);
                }

                if (Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x < -0.5f)
                {
                    Debug.Log(trackedObj.index + " Movement Dpad Left");
                    CamRig.transform.Translate(Vector3.left * Time.deltaTime * 6);
                }
            }
            */

            //------이게 되면 끝인데.....
            float xx = Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
            float zz = Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y;

            lookDirection = xx * Vector3.forward + zz * Vector3.right;

            CamRig.transform.rotation = Quaternion.LookRotation(lookDirection);
            eye.transform.rotation = Quaternion.identity;

            CamRig.transform.Translate(Vector3.forward * 6 * Time.deltaTime);
        }

    }
}
