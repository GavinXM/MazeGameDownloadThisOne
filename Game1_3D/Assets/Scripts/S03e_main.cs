using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S03e_main : MonoBehaviour
{

    public Vector3 axis = new Vector3(0, 1, 0);
    public float rotRpm = 10f;

    void Update()
    {
        float angle = rotRpm * Time.time / 60 * 360;
        gameObject.transform.localRotation = Quaternion.AngleAxis(angle, axis);


    }
}
