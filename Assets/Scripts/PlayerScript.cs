using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private CharacterController controller;
    public Camera playerCamera;
    public GameObject[] rightLegs;
    public GameObject[] leftLegs;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private int legFrame = 0;
    // Start is called before the first frame update
    void Start()
    {
                controller = gameObject.AddComponent<CharacterController>();
		rightLegs[0].SetActive(true);
            	rightLegs[1].SetActive(false);
            	rightLegs[2].SetActive(false);
            	leftLegs[0].SetActive(true);
            	leftLegs[1].SetActive(false);
            	leftLegs[2].SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }



        

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = playerCamera.transform.TransformDirection(move);
        //move.y = 0.0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            if(legFrame>30){
            	rightLegs[0].SetActive(false);
            	rightLegs[1].SetActive(true);
            	rightLegs[2].SetActive(false);
            	leftLegs[0].SetActive(false);
            	leftLegs[1].SetActive(false);
            	leftLegs[2].SetActive(true);
            }else if (legFrame>20){
            	rightLegs[0].SetActive(true);
            	rightLegs[1].SetActive(false);
            	rightLegs[2].SetActive(false);
            	leftLegs[0].SetActive(true);
            	leftLegs[1].SetActive(false);
            	leftLegs[2].SetActive(false);
            }else if (legFrame>10){
            	rightLegs[0].SetActive(false);
            	rightLegs[1].SetActive(false);
            	rightLegs[2].SetActive(true);
            	leftLegs[0].SetActive(false);
            	leftLegs[1].SetActive(true);
            	leftLegs[2].SetActive(false);
            }else{
            	rightLegs[0].SetActive(true);
            	rightLegs[1].SetActive(false);
            	rightLegs[2].SetActive(false);
            	leftLegs[0].SetActive(true);
            	leftLegs[1].SetActive(false);
            	leftLegs[2].SetActive(false);
            }
            
            legFrame = (legFrame + 1)%40;
        }else{
        	legFrame = 0;
        	rightLegs[0].SetActive(true);
            	rightLegs[1].SetActive(false);
            	rightLegs[2].SetActive(false);
            	leftLegs[0].SetActive(true);
            	leftLegs[1].SetActive(false);
            	leftLegs[2].SetActive(false);
        }

        // Changes the height position of the player..
        /*
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        */
    }
    
}
