using System.Collections;
using UnityEngine;
public class S03a_main : MonoBehaviour
{
    public GameObject target;
    private Camera _camera;
    private Vector3 offset = new Vector3(5, 6, -7);
    private bool reorientCam = true;
    // Use this for initialization
    void Start()
    {
        // discover the only camera of the scene and cache the result:
        _camera = GameObject.FindObjectOfType<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        _camera.transform.position = target.transform.position + offset;
        if (reorientCam)
        {
            // place the target at the center of the camera's view
            _camera.transform.LookAt(target.transform.position);
            reorientCam = false; // only need to reorient the camera once
        }
    }
}

