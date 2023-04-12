using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public GameObject character;
    public Camera playerCamera;
    private Vector3 offset;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public float rotationX = 0;
    // Start is called before the first frame update
    void Start()
    {
     	offset = transform.position - character.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        
        float newXPosition = character.transform.position.x;// - offset.x;
     	float newZPosition = character.transform.position.z;// - offset.z;
     	//float newYPosition = character.transform.position.y - offset.y;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX + 25, 0, 0);
        //transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
	
     	transform.SetPositionAndRotation(new Vector3(newXPosition, 0, newZPosition), transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0));
    }
}
