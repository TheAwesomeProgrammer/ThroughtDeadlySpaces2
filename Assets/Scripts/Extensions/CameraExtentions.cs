using UnityEngine;
using System.Collections;

public static class CameraExtentions {


    public static float GetCameraWidth(this Camera pCamera)
    {
        float tWidthOfCamera = 0;

        tWidthOfCamera = 2f * pCamera.orthographicSize * pCamera.aspect;

        return tWidthOfCamera;
    }

    public static float GetCameraHeight(this Camera pCamera)
    {
        float theightOfCamera = 0;

        theightOfCamera = 2f * pCamera.orthographicSize;

        return theightOfCamera;
    }

    public static Vector2 GetCameraSize(this Camera pCamera)
    {
        return new Vector2(pCamera.GetCameraWidth(), pCamera.GetCameraHeight());
    }
	
}
