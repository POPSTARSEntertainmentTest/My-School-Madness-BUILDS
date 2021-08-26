using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class StudentScriptBase : MonoBehaviour
{

    protected Vector3 moveTargetPosition;

    protected enum AnimationState
    {
        walk,
        run,
        talk,
        idle,
        sit,
        scared,
        none
    }

    protected AnimationState currentAnimationState = AnimationState.none;

    NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        TimeHandler._instance.onTimeChanged += onTimeChangedCalled;
    }

    protected virtual void onTimeChangedCalled(int hours = 0, int minutes = 0)
    {
        Debug.Log("//Student Command: Time Changed.");
    }

    protected Vector3 GoTo(Vector3 position){
        _navMeshAgent.SetDestination(position);
        return position;
    }

    protected void executeAnimation(string animation , Animator animator) => animator.Play(animation);

    protected void setAnimationState(AnimationState state)
    {
        currentAnimationState = state;
        switch (currentAnimationState)
        {
            case AnimationState.idle:
                //LOGIC AFTER
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(moveTargetPosition, 0.4f);
        Gizmos.DrawSphere(transform.position, 0.7f);

        if ((moveTargetPosition - transform.position).magnitude > 25)
            Gizmos.color = Color.red;
        else if ((moveTargetPosition - transform.position).magnitude > 15)
            Gizmos.color = Color.blue;
        else
            Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, moveTargetPosition);
    }
}
