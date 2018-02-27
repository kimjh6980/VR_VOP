//using UnityEngine;
//using System.Collections;
//public enum AIState
//{
//    None,
//    Patrol,
//    Chase,
//    Attack,

//}
//public class SimpleAI : FSM
//{
//    //AI상태
//    public Transform m_target;
//    public NavMeshAgent NavMonster;
//    public Transform[] WanderPoint;
//    public Transform Player;
//    public AIState Aistate;
//  //  AI의속도
//    float Speed;
// //   AI의 회전속도
//    float RotSpeed;
//    float ftime;
//    int m_iRandom;


//   // Use this for initialization

//   void Start()
//    {
//        Initialize();

//    }

//   // Update is called once per frame
//    void Update()
//    {
//        FSMUpdate();
//        if (Vector3.Distance(transform.position, Player.position) <= 10f)
//        {
//            NavMonster.SetDestination(Player.position);

//        }
//        if (Vector3.Distance(transform.position, m_target.position) <= 1f)
//        {

//        }
//        else if (Vector3.Distance(transform.position, WanderPoint[m_iRandom].position) <= 1f)
//        {
//            ftime = 0.0f;
//            m_iRandom = Random.Range(0, WanderPoint.Length);
//        }
//        else
//        {
//            ftime += Time.deltaTime;
//            if (ftime >= 20.0f)
//            {

//                m_iRandom = Random.Range(0, WanderPoint.Length);
//                ftime = 0.0f;
//            }
//            NavMonster.SetDestination(WanderPoint[m_iRandom].position);

//        }

//    }
//    protected override void Initialize()
//    {
//        //상태
//        Aistate = AIState.Patrol;
//        //WandarPoint위치 목록정보
//        PointList = GameObject.FindGameObjectsWithTag("WandarPoint");
//        FindNextPoint();
//        //적군(playr)정의
//        GameObject Playerobj = GameObject.FindGameObjectWithTag("Player");
//        playerTransform = Playerobj.transform;
//        //속도
//        Speed = 3;
//        RotSpeed = 2;

//    }
//    protected override void FSMUpdate()
//    {
//        switch (Aistate)
//        {
//            case AIState.Patrol: PatrolUpdate(); break;
//            case AIState.Chase: ChaseUpdate(); break;
//            case AIState.Attack: AttackUpdate(); break;

//        }
//    }
//    void PatrolUpdate()
//    {
//        //현재 포인트에 도달하면 다른 포인트를 찾는다
//        if (Vector3.Distance(transform.position, Nextpos) <= 5)
//        {
//            print("NextPoint\n");
//            FindNextPoint();
//        }
//        else if (Vector3.Distance(transform.position, playerTransform.position) <= 20)
//        {
//            Aistate = AIState.Chase;
//        }
//        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
//        //회전
//        Quaternion targetRoatation = Quaternion.LookRotation(Nextpos - transform.position);
//        //Quaternion.Slerp 이 객체의 Roatation으로부터 targetRoatation으로까지 Time.deltaTime*RotSpeed로움직인다.
//        transform.rotation = Quaternion.Slerp(transform.rotation, targetRoatation, Time.deltaTime * RotSpeed);

//    }
//    void ChaseUpdate()
//    {
//        Speed = 7;
//        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
//        Quaternion targetRoatation = Quaternion.LookRotation(playerTransform.position - transform.position);
//        transform.rotation = Quaternion.Slerp(transform.rotation, targetRoatation, Time.deltaTime * RotSpeed);
//        if (Vector3.Distance(transform.position, playerTransform.position) <= 10)
//        {
//            Aistate = AIState.Attack;
//        }
//        else if (Vector3.Distance(transform.position, playerTransform.position) >= 30)
//        {
//            Aistate = AIState.Patrol;
//        }
//    }
//    void AttackUpdate()
//    {
//        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
//        Quaternion targetRoatation = Quaternion.LookRotation(playerTransform.position - transform.position);
//        transform.rotation = Quaternion.Slerp(transform.rotation, targetRoatation, Time.deltaTime * RotSpeed);
//        if (Vector3.Distance(playerTransform.position, transform.position) >= 20)
//        {
//            Aistate = AIState.Chase;
//        }
//        else
//        {
//            Aistate = AIState.Attack;
//        }
//    }
//    void FindNextPoint()
//    {
//        //Random.Range(최소값,최대값)
//        int random = Random.Range(0, PointList.Length);
//        Nextpos = PointList[random].transform.position;
//    }
//}
