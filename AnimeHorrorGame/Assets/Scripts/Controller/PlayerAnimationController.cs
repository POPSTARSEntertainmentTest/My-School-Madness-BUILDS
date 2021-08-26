using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [HideInInspector]
    public Animator meshAnimator;

    void Start() => meshAnimator = GetComponentInChildren<Animator>();

    public void setFloatParam(string name , float value) => meshAnimator.SetFloat(name,value);

    public void setBooleanParam(string name , bool value) => meshAnimator.SetBool(name,value);
}
