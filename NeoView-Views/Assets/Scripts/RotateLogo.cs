using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateLogo : MonoBehaviour
{
    public float speed = 10f;


    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), speed * Time.deltaTime);
    }
}