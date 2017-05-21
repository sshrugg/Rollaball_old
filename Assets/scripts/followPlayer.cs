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
    void Update()
    {

        //horizontal movement of camera with mouse
        if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("JoystickX") > 0)
        {
            RotateCamera(Vector3.up);
        }
        else if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("JoystickX") < 0)
        {
            RotateCamera(Vector3.down);
        }
        //update camera position without rotation if mouse position is static
        else
        {
            RotateCamera(Vector3.zero);
        }
    }

    private void RotateCamera(Vector3 direction)
    {
        transform.position = player.transform.position + offset;
        transform.RotateAround(player.transform.position, direction, offset.magnitude);
        setOffset();
    }
}
