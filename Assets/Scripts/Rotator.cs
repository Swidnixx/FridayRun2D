using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 100;

    void Start()
    {
        speed = Random.Range(0.75f * speed, 1.25f * speed);
    }

    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
