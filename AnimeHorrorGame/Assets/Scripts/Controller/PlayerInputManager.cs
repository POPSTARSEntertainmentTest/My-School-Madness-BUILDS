using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public Vector3 movementAxis;
    public bool isCrouchKey, isHoldingRunKey;

    void Update()
    {
        movementAxis = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        isCrouchKey = Input.GetKeyDown(KeyCode.LeftControl);
        isHoldingRunKey = Input.GetKey(KeyCode.LeftShift);
    }
}
