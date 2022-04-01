using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    public Transform floor1;
    public Transform floor2;
    public float speed = 0.1f;

    void FixedUpdate()
    {
        floor1.position -= new Vector3(speed, 0, 0);
        floor2.position -= new Vector3(speed, 0, 0);

        if(floor2.position.x <= 0)
        {
            floor1.position += new Vector3(40, 0, 0);

            var tmp = floor1;
            floor1 = floor2;
            floor2 = tmp;
        }
    }
}
