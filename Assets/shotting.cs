using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shotting : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;
    // 추적할 오브젝트의 레퍼런스를 선언
    public GameObject laser;    // Laser prefab의 레퍼런스

    private Ray ray;
    private RaycastHit hit;
    public GameObject bullet;
    private int effect = 1;

    //public GameObject particle_effect;

    private SteamVR_Controller.Device Controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start()
    {
        laser.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward; // 발사방향

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {  
            GameObject bul = Instantiate(bullet, this.transform.position + new Vector3(0f, 0.15f, 0f), this.transform.rotation);

            if (Physics.Raycast(ray, out hit, 100) && hit.collider.gameObject != GameObject.Find("Plane"))
            {
                if (hit.collider.gameObject == GameObject.Find("waterset"))
                {   // 수중
                    Debug.Log("수중");
                    //ToEnd = true;
                    SceneManager.LoadScene("deepsea_Vive");
                }
                else if (hit.collider.gameObject == GameObject.Find("highset"))
                {   // 고소
                    Debug.Log("고소");
                    //ToEnd = true;
                    SceneManager.LoadScene("HIGH");
                }
                
            }
            Destroy(bul, 2.0f); // 총알 객체 파괴.

        }
        else
        {
            laser.transform.localScale = new Vector3(0.005f, 0.005f, 1.0f);
            laser.SetActive(false);
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
