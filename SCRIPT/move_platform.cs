using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_platform : MonoBehaviour
{
    [SerializeField] GameObject[] points;
    int index = 0;

    [SerializeField] float speed;
    void Update()
    {
        if (Vector2.Distance(points[index].transform.position, transform.position) < .1f)
        {
            index++;
            if(index >= points.Length)
            {
                index= 0;
            }
        }
        transform.position= Vector2.MoveTowards(transform.position, points[index].transform.position, Time.deltaTime*speed);
    }

   
}
