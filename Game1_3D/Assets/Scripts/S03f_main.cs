using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S03f_main : MonoBehaviour
{

    // Earth’s rotation: Earth spins on its axis, one counterclockwise rotation every 24 hours.
    // Earth’s revolution: Earth goes around the sun, one counterclockwise revolution every 365 days.

    // following numbers are for looks-and-feels, have NO real meaning!
    private float revRadius = 3.4f;
    private float rotSpeed = 210f;
    private float revSpeed = 0.6f;
    private Vector3 rotAxis = new Vector3(0.3f, 1, 0);

    void Update()
    {
        float t = Time.time;
        // Earth's revolution around the sun:
        float posX = revRadius * Mathf.Cos(revSpeed * t);
        float posZ = revRadius * Mathf.Sin(revSpeed * t);
        float posY = 0;
        gameObject.transform.position = new Vector3(posX, posY, posZ);
        // Earth's rotation about its own axis (self-spinning):
        float rot = rotSpeed * t;
        gameObject.transform.localRotation = Quaternion.AngleAxis(rot, rotAxis);
    }
}
