using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S03d_main : MonoBehaviour
{

    void Update()
    {
        float y = 67f * Time.time;
        gameObject.transform.localRotation = Quaternion.Euler(0, y, 0);
    }
}
