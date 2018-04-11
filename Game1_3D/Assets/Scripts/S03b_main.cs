using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S03b_main : MonoBehaviour
{

    public GameObject target;
    public float horzRadius = 6;
    public float vertDist = 6;
    public float orbitSpeed = 0.3f;

    private Camera _camera;

    // Use this for initialization
    void Start()
    {
        // discover the only camera of the scene and cache the result:
        _camera = GameObject.FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = orbitSpeed * Time.time;
        float x = horzRadius * Mathf.Cos(t);
        float z = horzRadius * Mathf.Sin(t);
        float y = vertDist;
        Vector3 offset = new Vector3(x, y, z);
        _camera.transform.position = target.transform.position + offset;
        // place the target at the center of the camera's view
        _camera.transform.LookAt(target.transform.position);
    }

}

