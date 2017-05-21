using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;

    void setOffset()
    {
        offset = transform.position - player.transform.position;
    }

	// Use this for initialization
	void Start () {
        setOffset();
    }

    // Update is called once per frame
    void Update() {
    }

    private void FixedUpdate()
    {
        //transform.position = player.transform.position + offset;
        if (Input.GetAxis("Mouse X") > 0)
        {
            RotateCamera(Vector3.up);
        }
        else if (Input.GetAxis("Mouse X") < 0)
        {
            RotateCamera(Vector3.down);
        }
        else
        {
            transform.position = player.transform.position + offset;
        }
    }

    private void RotateCamera(Vector3 direction)
    {
        transform.position = player.transform.position + offset;
        transform.RotateAround(player.transform.position, direction, offset.magnitude);
        setOffset();
    }
}
