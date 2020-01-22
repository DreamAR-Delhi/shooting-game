using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
  float cubeRotationSpeed = 200f, timeElapsed = 0;
  public GameObject obstaclePrefab, bulletPrefab;
  public Vector3 bulletDirection;
  public float screenHalfWidth, screenHalfHeight;
  public int score = 0;

  void Start()
  {
    screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
    screenHalfHeight = Camera.main.orthographicSize;
  }

  void Update()
  {
    Ray ray = new Ray(transform.position, transform.up);
    RaycastHit hitInfo;

    if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag != "bullet")
      Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
    else
      Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.cyan);

    if (Input.GetKeyDown(KeyCode.Space))
    {
      bulletDirection = ray.direction;
      Instantiate(bulletPrefab, ray.origin, Quaternion.Euler(Vector3.zero));
    }

    timeElapsed += Time.deltaTime;
    if (timeElapsed >= 0.25)
    {
      timeElapsed = 0;
      Instantiate(obstaclePrefab, new Vector3(Random.Range(-screenHalfWidth + 0.7f, screenHalfWidth - 0.7f), screenHalfHeight + 5, 0), Quaternion.Euler(Vector3.zero));
    }

    float direction = -Input.GetAxisRaw("Horizontal");

    float angularVelocity = cubeRotationSpeed * direction;
    float rotateAmount = angularVelocity * Time.deltaTime;

    transform.Rotate(0, 0, rotateAmount);
  }
}
