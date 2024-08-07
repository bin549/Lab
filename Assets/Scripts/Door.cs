using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Door : MonoBehaviour {
	public bool open;
	public float smooth = 1.0f;
	float DoorOpenAngle = -90.0f;
    float DoorCloseAngle = 0.0f;
	public AudioSource audioSource;
	public AudioClip openDoor,closeDoor;

	private void Awake () {
		audioSource = GetComponent<AudioSource>();
	}
	
	private void Update() {
		if (open)
		{
            var target = Quaternion.Euler(0, DoorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * 5 * smooth);
	
		}
		else
		{
            var target1= Quaternion.Euler(0, DoorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * 5 * smooth);
	
		}  
	}

	public void OpenDoor(){
		open =!open;
		audioSource.clip = open?openDoor:closeDoor;
		audioSource.Play ();
	}
}

// 	public float DistanceOpen=3;
// 	public GameObject text;
// 	// Use this for initialization
// 	void Start () {
		
// 	}
	
// 	// Update is called once per frame
// 	void Update () {
// 		RaycastHit hit;
// 		if (Physics.Raycast (transform.position, transform.forward, out hit, DistanceOpen)) {
// 				if (hit.transform.GetComponent<DoorScript.Door> ()) {
// 				text.SetActive (true);
// 				if (Input.GetKeyDown(KeyCode.E))
// 					hit.transform.GetComponent<DoorScript.Door> ().OpenDoor();
// 			}else{
// 				text.SetActive (false);
// 			}
// 		}else{
// 			text.SetActive (false);
// 		}
// 	}
// }


    // [RequireComponent(typeof(CharacterController))]

    // public class FPSController : MonoBehaviour
    // {
    //     public float walkingSpeed = 7.5f;
    //     public float runningSpeed = 11.5f;
    //     public float jumpSpeed = 8.0f;
    //     public float gravity = 20.0f;
    //     public Camera playerCamera;
    //     public float lookSpeed = 2.0f;
    //     public float lookXLimit = 45.0f;

    //     CharacterController characterController;
    //     Vector3 moveDirection = Vector3.zero;
    //     float rotationX = 0;

    //     [HideInInspector]
    //     public bool canMove = true;

    //     void Start()
    //     {
    //         characterController = GetComponent<CharacterController>();

    //         // Lock cursor
    //         Cursor.lockState = CursorLockMode.Locked;
    //         Cursor.visible = false;
    //     }

    //     void Update()
    //     {
    //         // We are grounded, so recalculate move direction based on axes
    //         Vector3 forward = transform.TransformDirection(Vector3.forward);
    //         Vector3 right = transform.TransformDirection(Vector3.right);
    //         // Press Left Shift to run
    //         bool isRunning = Input.GetKey(KeyCode.LeftShift);
    //         float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
    //         float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
    //         float movementDirectionY = moveDirection.y;
    //         moveDirection = (forward * curSpeedX) + (right * curSpeedY);

    //         if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
    //         {
    //             moveDirection.y = jumpSpeed;
    //         }
    //         else
    //         {
    //             moveDirection.y = movementDirectionY;
    //         }

    //         // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
    //         // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
    //         // as an acceleration (ms^-2)
    //         if (!characterController.isGrounded)
    //         {
    //             moveDirection.y -= gravity * Time.deltaTime;
    //         }

    //         // Move the controller
    //         characterController.Move(moveDirection * Time.deltaTime);

    //         // Player and Camera rotation
    //         if (canMove)
    //         {
    //             rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
    //             rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
    //             playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    //             transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    //         }
    //     }
    // }