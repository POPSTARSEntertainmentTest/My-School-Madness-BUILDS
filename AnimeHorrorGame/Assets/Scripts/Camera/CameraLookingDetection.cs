using UnityEngine;

public class CameraLookingDetection : MonoBehaviour
{
    public static bool isRenderedByCamera(Camera camera , GameObject targetObj){
        var planes = GeometryUtility.CalculateFrustumPlanes(camera);
        var objPosition = targetObj.transform.position;
        foreach(var plane in planes){
            if (plane.GetDistanceToPoint(objPosition) < 0)
                return false;
        }

        return true;
    }
}
