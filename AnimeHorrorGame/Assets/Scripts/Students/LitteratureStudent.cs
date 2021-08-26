using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitteratureStudent : StudentScriptBase
{
    public studentType _studentType;

    public studentCharacterTrait _studentCharacterTrait;

    public LitteratureStudent()
    {
        
    }
    
    protected override void onTimeChangedCalled(int hours = 0, int minutes = 0)
    {
        moveTargetPosition = GoTo(transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)));
    }
}
