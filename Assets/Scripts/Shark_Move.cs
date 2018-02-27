using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Shark_Move : MonoBehaviour
{
    public NavMeshAgent Nav_Shark;
    public Transform[] Move_Point;
    public Transform Player;
    bool bPlayerchase=true;
    public float Distance;
    private int iRnadomPoint;
    private float fCheckTime;
    private float fChaseTime;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, Player.position) <= Distance&&bPlayerchase)
        {

            
                bPlayerchase = !bPlayerchase;
            Nav_Shark.speed = 15;
                Debug.Log("상어 뵜다 간다 잡느다");
            


        }
        else
        {
            if (!bPlayerchase)
            {
                fChaseTime += Time.deltaTime;
                if(fChaseTime>=10||Vector3.Distance(transform.position,Player.position)>=40)
                {
                    fChaseTime = 0.0f;
                    Nav_Shark.speed = 5f;
                    bPlayerchase = true;
                }
                Nav_Shark.destination = Player.position;
            }
        else
            {
                if (Vector3.Distance(transform.position, Move_Point[iRnadomPoint].position) <= 0.0)
                {
                    fCheckTime = 0.0f;
                    iRnadomPoint = Random.Range(0, Move_Point.Length);
                }
                else if (fCheckTime >= 20f)
                {
                    fCheckTime = 0.0f;
                    iRnadomPoint = Random.Range(0, Move_Point.Length);

                }
                fCheckTime += Time.deltaTime;
                Nav_Shark.destination = Move_Point[iRnadomPoint].position;
            }
       
        }
         
        
    }
}
