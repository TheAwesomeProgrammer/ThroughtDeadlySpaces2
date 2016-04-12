using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public static class TranformExtension {

    public static Transform FindChildByTag(this Transform pTransformRoot, string tag)
    {
        foreach (Transform tChild in pTransformRoot.GetComponentsInChildren<Transform>())
        {
            if (tChild != pTransformRoot && tChild.tag == tag) return tChild;
        }
        Debug.LogWarning("Tag " + tag + " not found in any children of " + pTransformRoot.name);
        return null;
    }

    public static List<Transform> FindChildsByTag(this Transform pTransformRoot, string tag)
    {
        List<Transform> tChildsWithTag = new List<Transform>();

        foreach (Transform tChild in pTransformRoot.GetComponentsInChildren<Transform>())
        {
            if (tChild != pTransformRoot && tChild.tag == tag)
            {
                tChildsWithTag.Add(tChild);
            }
        }

        return tChildsWithTag;
    }

    public static T FindComponentInChildWithTag<T>(this Transform pTransformRoot, string tag) where T : Component
    {
        foreach (T tChild in pTransformRoot.GetComponentsInChildren<T>())
        {
            if (tChild.tag == tag)
            {
                return tChild.GetComponent<T>();
            }
        }

        return null;
    }

    public static IEnumerator MoveToPosition(this Transform pTransform,Vector3 pPositionToMoveTo,float pSpeed,CallbackInfo pCallBackInfo)
    {
        pPositionToMoveTo.z = pTransform.position.z;

        while(Vector2.Distance(pTransform.position,pPositionToMoveTo) > 0.01f)
        {
            pTransform.position = Vector3.Lerp(pTransform.position, pPositionToMoveTo, pSpeed * Time.deltaTime);
            yield return 0;
        }

        pCallBackInfo.ObjectToCall.SendMessage(pCallBackInfo.MethodName);
    }

   

}
