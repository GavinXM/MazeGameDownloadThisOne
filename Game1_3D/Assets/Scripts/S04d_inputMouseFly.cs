using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S04d_inputMouseFly : MonoBehaviour {

  public float accel = 250f;
  public float pitchSpeed = 15;
  public float yawSpeed = 15;

  private const float MAX_FLY_SPEED = 15;

  private float flySpeed = 10;

  void Update() {
    if(Input.GetKeyDown(KeyCode.Space)) {
      flySpeed = 0;
      transform.position = new Vector3(0, 10, 0);
      float yaw = Random.Range(0, 360f);
      transform.localRotation = Quaternion.Euler(0, yaw, 0);
    } else {
      float dt = Time.deltaTime;
      float yaw = yawSpeed * dt * Input.GetAxis("Mouse X");
      float pitch = pitchSpeed * dt * Input.GetAxis("Mouse Y");
      flySpeed += accel * dt * Input.GetAxis("Mouse ScrollWheel");
      flySpeed = Mathf.Clamp(flySpeed, 0, MAX_FLY_SPEED);
      transform.Rotate(pitch, yaw, 0);
      transform.position += flySpeed * dt * transform.forward;
    }
  }




}
