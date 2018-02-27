using UnityEngine;
using System.Collections;

public class FPSCamera : MonoBehaviour
{
    Vector3 SeeDirction = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        SeeDirction = new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);
        transform.Rotate(SeeDirction * 2);
    }
}
