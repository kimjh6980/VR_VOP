using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIGH_POSITION : MonoBehaviour {

    // 타켓 지정
    public GameObject view;
    public Transform viewTrans;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void H_Position1()  // 12345 만들거임
    {
        viewTrans.position = new Vector3(0, 0, 0);
        // 이거 아니다 수정해야됨
    }
    public void H_Position2()  // 12345 만들거임
    {
        viewTrans.position = new Vector3(-100, 1, 0);
        // 이거 아니다 수정해야됨
    }
    public void H_Position3()  // 12345 만들거임
    {
        viewTrans.position = new Vector3(-110, 5, 0);
        // 이거 아니다 수정해야됨
    }
    public void H_Position4()  // 12345 만들거임
    {
        viewTrans.position = new Vector3(-130, 10, 0);
        // 이거 아니다 수정해야됨
    }
    public void H_Position5()  // 12345 만들거임
    {
        viewTrans.position = new Vector3(-150, 15, 0);
        // 이거 아니다 수정해야됨
    }
}
