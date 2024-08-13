using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour {
    public float projectileSpeed = 30f;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();

        //AddForce: We apply a force in the forward direction using Rigidbody.AddForce. The ForceMode.VelocityChange mode is used to instantly change the velocity without considering the object's mass.
        //Start Method: This is done in the Start method so that the force is applied only once when the projectile is created.
        //also lock XYZ on charecter to prevent the forces affecting him after shooting alot
        rb.AddForce(transform.forward * projectileSpeed, ForceMode.VelocityChange);
    }


    void Update() {
        //transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Animal") {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        // Check if the projectile collided with the Ground
        if (collision.transform.CompareTag("Ground")) {
            Destroy(gameObject);
        }
    }
}