using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    private Rigidbody rb;
    [Range (1, 50)]
    public float speedMultiplier;
    private Vector3 vec;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        vec.x = Input.GetAxis("Horizontal");
        vec.z = Input.GetAxis("Vertical");
        vec = Camera.main.transform.TransformDirection(vec);  // Make relative to main camera
        vec.y = 0;  // optional for no y movement.
        Vector3 force = vec.normalized * speedMultiplier;
        rb.AddForce(force);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
        }
    }
}