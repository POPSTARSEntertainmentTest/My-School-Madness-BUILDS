using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CONTROLLER_STATE
{
    walk,
    run,
    crouched
}

[RequireComponent(typeof(PlayerInputManager))]
public class PlayerController : MonoBehaviour
{
    public float walk_Speed , run_Speed , crouch_Speed,gravity;

    [SerializeField]
    float meshTurnSpeed;

    bool isCrouched;

    [SerializeField]
    Transform cameraTransform,playerMesh;

    PlayerInputManager playerInputManager;

    CONTROLLER_STATE currentControllerState;

    PlayerAnimationController animationController;

    CharacterController characterController;

    [HideInInspector]
    public Vector3 velocity,gravityVelocity;

    void Start()
    {
        MouseManager.setMouseLocked(true);
        characterController = GetComponent<CharacterController>();
        playerInputManager = GetComponent<PlayerInputManager>();
        animationController = GetComponent<PlayerAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        //tmp variable to keep track of the current Speed
        float currentSpeed = 0f;

        //State Controller
        if (playerInputManager.isHoldingRunKey && !isCrouched) { currentControllerState = CONTROLLER_STATE.run; }
        else if (isCrouched) { currentControllerState = CONTROLLER_STATE.crouched; }
        else { currentControllerState = CONTROLLER_STATE.walk; }

        //Set the controller state. (better with switch then else if boysss)
        switch (currentControllerState)
        {
            case CONTROLLER_STATE.walk:
                currentSpeed = walk_Speed;
                break;
            case CONTROLLER_STATE.run:
                currentSpeed = run_Speed;
                break;
            case CONTROLLER_STATE.crouched:
                currentSpeed = crouch_Speed;
                break;
        }

        velocity = ((cameraTransform.right * playerInputManager.movementAxis.x + cameraTransform.forward * playerInputManager.movementAxis.y) * currentSpeed);
        velocity.y = 0f;
        animationController.setFloatParam("moveF",velocity.magnitude);
        animationController.setBooleanParam("isCrouched",isCrouched);
        animationController.setBooleanParam("isRunning", playerInputManager.isHoldingRunKey && !isCrouched);
        if (velocity.magnitude > 0f){
            float faceAngle = Mathf.Atan2(playerInputManager.movementAxis.x, playerInputManager.movementAxis.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            playerMesh.rotation = Quaternion.Lerp(playerMesh.rotation, Quaternion.Euler(new Vector3(0,faceAngle,0)), meshTurnSpeed * Time.deltaTime);
        }
        characterController.Move(velocity * Time.deltaTime);

        //USING ANOTHER VELOCITY VARIABLE BC IF OUR PLAYER LOOKS UP WITH OUR CAM HE WILL JUST FLY TO PREVENT THAT WE SET THE VELOCITY.Y TO 0 AND CREATE A SECONDARY VARIABLE TO HANDLE GRAVITY
        if (characterController.isGrounded)
            gravityVelocity.y = 0;
        else
            gravityVelocity.y -= gravity * Time.deltaTime; //Maths yeah!

        characterController.Move(gravityVelocity * Time.deltaTime);

    }
}
