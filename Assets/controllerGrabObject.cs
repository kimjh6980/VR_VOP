using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerGrabObject : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    private GameObject collidingObject;
    private GameObject objectInHand;

    public GameObject lv1k;
    public GameObject lv2k;
    public GameObject lv3k;
    public GameObject nextP1;
    public GameObject nextP2;
    public GameObject nextP3;

    private SteamVR_Controller.Device Controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }

    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>()) { return; }
        collidingObject = col.gameObject;
    }

    //-------------여기는 트리거
    public void OnTriggerEnter(Collider other)
    {   if(other.tag == "next" && collidingObject.tag == "key")
        {
            if(other.gameObject.name == "lvk1")
            {
                // 2단계
            }   else if(other.gameObject.name == "lvk2")
            {
                // 3단계1
            }   else if(other.gameObject.name == "lvk3")
            {
                // 끝
            }
            collexit();
            ReleaseObject();
        }
        else {
            // trigger collider가 다른 coolider에 진입했을 떄 다른 collider을 움켜 쥘 수 있는 잠재적 타켓
            SetCollidingObject(other);
        }
        
        
    }
    public void OnTriggerStay(Collider other)
    {   // 위와 유사하나, 차이점은 두개의 collider가 겹친 상태 유지시 setColliding호출. 이거 없이 위의 경우는 collision체크 실패 확률 존대
        if (other.tag == "next" && collidingObject.tag == "key")
        {
            if (other.gameObject.name == "lvk1")
            {
                // 2단계
            }
            else if (other.gameObject.name == "lvk2")
            {
                // 3단계1
            }
            else if (other.gameObject.name == "lvk3")
            {
                // 끝
            }
            collexit();
            ReleaseObject();
        }
        else
        {
            // trigger collider가 다른 coolider에 진입했을 떄 다른 collider을 움켜 쥘 수 있는 잠재적 타켓
            SetCollidingObject(other);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        collexit();
    }

    public void collexit()
    {
        // collider가 trigger collider로부터 떨어졌을 떄 이 물체를 collidingObject가 아닌 null로 설정
        if (!collidingObject)
        {
            return;
        }
        collidingObject = null;
    }

    //---------------------물체를 잡는 행위
    private void GrabObject()
    {
        // 1    손 안에 GameObject를 옮기고 collidingObject초기화
        objectInHand = collidingObject;
        collidingObject = null;
        // 2    joint하나 만들고 addFixedJoint를 사용하여 현재 접촉한 오브젝트를 컨트롤러에 연결
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    // 3    새 fixed joint를 만드는 함수이며, 이를 controller의 컴포넌트로 등록 및 이 조인트가 쉽게 떨어지지 않도록 강하게 고정, 결과값 반환
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    // ---------쥐고 있는 오브젝트 놓기
    private void ReleaseObject()
    {
        // 1    컨트롤러에 연결된 fixed joint를 가지고 있는지 확인
        if (GetComponent<FixedJoint>())
        {
            // 2    joint연결 끊고, fixedjoint삭제
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3    콘트롤러의 속도와 각 속도를 버려질 물체에 부과하여 사실적인 버려짐을 구현
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity =
           Controller.angularVelocity;
        }
        // 4    물체가 쥐어져있다는 것을 표현했던 objectInHand해제
        objectInHand = null;

    }

    // Update is called once per frame
    void Update () {
        // 1    플레이어가 hair trigger를 눌렀을 때, 이때 접촉하고 있는 물체가 있다면 이를 잡는다.
        if (Controller.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        // 2    플레이어가 hair trigger를 놓았을 때, 콘트롤러에 붙어 있던 물체는 떨어진다.
        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
    }
}
