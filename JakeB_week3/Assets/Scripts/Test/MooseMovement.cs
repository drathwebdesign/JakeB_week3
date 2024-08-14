using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooseMovement : MonoBehaviour
{

    public float movementSpeed = 8f;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
    }


    void Update()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
}