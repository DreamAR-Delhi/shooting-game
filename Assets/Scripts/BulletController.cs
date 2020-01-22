using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
  float speed = 70f;
  Vector3 direction;
  Text score;

  void Start()
  {
    transform.parent = GameObject.Find("Bullets").transform;
    direction = FindObjectOfType<CubeController>().bulletDirection;

    score = FindObjectOfType<Text>();
  }

  void FixedUpdate()
  {
    transform.position += speed * direction * Time.fixedDeltaTime;

    if (Math.Abs(transform.position.y) > FindObjectOfType<CubeController>().screenHalfHeight + 10 || Math.Abs(transform.position.x) > FindObjectOfType<CubeController>().screenHalfWidth + 10)
      Destroy(gameObject);
  }

  private void OnCollisionEnter(Collision other)
  {
    FindObjectOfType<CubeController>().score += 10;
    score.text = "Score: " + FindObjectOfType<CubeController>().score.ToString();

    Destroy(other.gameObject);
    Destroy(gameObject);
  }
}
