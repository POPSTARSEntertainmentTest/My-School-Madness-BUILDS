using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static void setMouseLocked(bool isLocked) => Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.Confined;
}
