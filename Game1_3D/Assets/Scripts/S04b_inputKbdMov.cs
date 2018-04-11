using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S04b_inputKbdMov : MonoBehaviour {

  public float speed = 3.0f;

  void Update() {
    if(Input.GetKeyDown(KeyCode.Space)) {
      transform.position = new Vector3(0, 0.5f, 0);
    } else {
      float dt = Time.deltaTime;
      float dx = Input.GetAxis("Horizontal"); // left/right arrow keys (AD keys)
      float dz = Input.GetAxis("Vertical");   // up/down arrow keys (WS keys)
      // The values of x and z are between -1.0 and 1.0
      // Debug.Log(string.Format("x={0,4}  z={1,4}", x, z));
      float x = transform.position.x;
      float z = transform.position.z;
      x += speed * dt * dx;
      z += speed * dt * dz;
      transform.position = new Vector3(x, 0.5f, z);
    }
  }



}
