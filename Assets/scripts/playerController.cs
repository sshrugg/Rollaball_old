using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {
    private Rigidbody rb;
    private int count;
    [Range (1, 50)]
    public float speedMultiplier;
    private Vector3 vec;
    public Text countText;
    public Text winText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
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
     

    //grab pickups and add to score on collision
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            countText.text = count.ToString();
            
            //temporary "WIN" calculation
            if (count >= 8)
            {
                winText.text = "WIN!";
            }
        }
    }
}