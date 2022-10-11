using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript2 : MonoBehaviour
{
    public float playerSpeed = 10f;

    public float swimSpeed = 4f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Swim();
        Movement();
    }

    void Movement()
    {
        float forwardMovement = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        float sideMovement = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * forwardMovement);
        transform.Rotate(new Vector3(0, 23, 0) * sideMovement);
    }

    void Swim()
    {

        float swimupMovement = Input.GetAxis("Jump") * swimSpeed * Time.deltaTime;
        float swimdownMovement = Input.GetAxis("Unjump") * swimSpeed * Time.deltaTime;

        transform.Translate(new Vector3(0, 2, 0) * swimupMovement);
        transform.Translate(new Vector3(0, -2, 0) * swimdownMovement);
    }
}