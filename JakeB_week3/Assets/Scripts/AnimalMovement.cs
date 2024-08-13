using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float lowerBound = -5;


    void Start()
    {
        
    }


    void Update()
    {
        lowerBoundDestroy();
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void lowerBoundDestroy() {
        if (transform.position.z < lowerBound) {
            Destroy(gameObject);
        }
    }
}
