using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    Vector3 Driciton = Vector3.zero;
    Vector3 SeeDriction = Vector3.zero;
    public float Speed=0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        FpsCamera();
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.W))
            Driciton = Vector3.forward;
        else if (Input.GetKey(KeyCode.S))
            Driciton = Vector3.back;
        else if (Input.GetKey(KeyCode.A))
            Driciton = Vector3.left;
        else if (Input.GetKey(KeyCode.D))
            Driciton = Vector3.right;
        else
            Driciton = Vector3.zero;

        transform.Translate(Driciton * Time.deltaTime*Speed);

    }
    void FpsCamera()
    {
        SeeDriction = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        transform.Rotate(SeeDriction*2);
    }
}

