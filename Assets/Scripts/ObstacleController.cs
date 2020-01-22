using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
  float speed = 10f;

  void Start()
  {
    transform.parent = GameObject.Find("Obstacles").transform;
  }

  void Update()
  {
    if (Math.Abs(transform.position.y) > FindObjectOfType<CubeController>().screenHalfHeight + 10 || Math.Abs(transform.position.x) > FindObjectOfType<CubeController>().screenHalfWidth + 10)
      Destroy(gameObject);
  }

  void FixedUpdate()
  {
    transform.position += speed * Vector3.down * Time.fixedDeltaTime;
  }
}
