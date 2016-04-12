using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CallbackInfo
{
    public GameObject ObjectToCall;
    public string MethodName;

    
    public CallbackInfo(GameObject pObjectToCall,string pMethodName)
    {
        ObjectToCall = pObjectToCall;
        MethodName = pMethodName;
    }
}

public class TimingInfo
{
    public CallbackInfo TheCallBackInfo;
    public float Timer;
    
    public TimingInfo(CallbackInfo pTheCallBackInfo,float pTimer)
    {
        TheCallBackInfo = pTheCallBackInfo;
        Timer = pTimer;
    }
}

public class Timer : MonoBehaviour 
{
    private static List<TimingInfo> mTimers;
    private List<TimingInfo> mTimersToBeDestroyed;

    void Awake()
    {
        mTimers = new List<TimingInfo>();
        mTimersToBeDestroyed = new List<TimingInfo>();
        StartCoroutine(MakeLoop());
    }

    public static void Start(float pDurationOfTimer, GameObject pObjectToCall, string pMethodName)
    {
        Start(pDurationOfTimer, new CallbackInfo(pObjectToCall, pMethodName));    
    }

    public static void Start(float pDurationOfTimer,CallbackInfo pCallbackInfo)
    {
        mTimers.Add(new TimingInfo(pCallbackInfo,pDurationOfTimer));           
    }


    IEnumerator MakeLoop()
    {
        while(true)
        {
            if (mTimers.Count > 0)
            {
                CheckTimers();
                CountDownTimers();
            }
            yield return 0;
        }
    }

    void CheckTimers()
    {
        foreach (TimingInfo tTimingInfo in mTimers)
        {
            if(tTimingInfo.Timer <= 0)
            {
                mTimersToBeDestroyed.Add(tTimingInfo);
            }
        }

        foreach(TimingInfo tTimingInfo in mTimersToBeDestroyed)
        {
            TimerCallBack(tTimingInfo.TheCallBackInfo);
            mTimers.Remove(tTimingInfo);
        }

        mTimersToBeDestroyed.Clear();
    }

    void TimerCallBack(CallbackInfo pCallBackInfo)
    {
        GameObject tObjectToCall = pCallBackInfo.ObjectToCall;
        if (tObjectToCall && tObjectToCall.activeSelf)
        {
            tObjectToCall.SendMessage(pCallBackInfo.MethodName);
        }
    }

    void CountDownTimers()
    {
        foreach(TimingInfo tTimingInfo in mTimers)
        {
            tTimingInfo.Timer -= Time.deltaTime;
        }
    }

   
	
}
