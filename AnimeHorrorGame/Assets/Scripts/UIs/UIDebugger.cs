using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDebugger : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] 
    private TextMeshProUGUI plrVelocityText,plrGravityVelocityText,CurrentActionStateText,plrMagnitudeText,FPSText,FrameRenderTimeText,graphhicCardText,processorText,fpsStatusText; 
    [SerializeField]
    GameObject DebuggerGUI;

    PlayerAnimationController animationController;

    PlayerController playerController;

    void Start(){
        animationController = FindObjectOfType<PlayerAnimationController>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2)) { DebuggerGUI.SetActive(!DebuggerGUI.activeSelf); }

        if (DebuggerGUI.activeSelf)
        {
            plrVelocityText.text = playerController.velocity.ToString();
            plrGravityVelocityText.text = playerController.gravityVelocity.y < -10 ? (int)playerController.gravityVelocity.y + "( ▼ )" : (int)playerController.gravityVelocity.y + "( ~ )";
            plrMagnitudeText.text = playerController.velocity.magnitude.ToString();
            int FPS = (int)(1.0f / Time.smoothDeltaTime);
            FPSText.text = FPS.ToString() + "FPS";
            FrameRenderTimeText.text = ((int)(Time.deltaTime * 60)).ToString() + "ms";
            if (FPS > 60) { fpsStatusText.text = "OPTIMAL"; }
            else if (FPS > 45 && FPS < 90) { fpsStatusText.text = "MEDIOCRE"; }
            else { fpsStatusText.text = "SEVERELY LOW"; }
            graphhicCardText.text = SystemInfo.graphicsDeviceName;
            processorText.text = SystemInfo.processorType;
        }
    }
#endif
}
