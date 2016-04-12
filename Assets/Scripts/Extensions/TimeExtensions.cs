using UnityEngine;
using System.Collections;

public static class TimeExtensions {

    public static float GetTimer(this Transform pTransform,float pCurrentTime,float pTimeToAdd)
    {
        float tTimer = 0;
     
        tTimer = pCurrentTime + pTimeToAdd;        

        return tTimer;
    }

    public static IEnumerator GetTimer(this Transform pTransform, float pCurrentTime, float pTimeToAdd, string pCallBackMethod)
    {
        float tTimer = 0;

        tTimer = pCurrentTime + pTimeToAdd;

        yield return new WaitForSeconds(tTimer);
        pTransform.SendMessage(pCallBackMethod);
    }
}
