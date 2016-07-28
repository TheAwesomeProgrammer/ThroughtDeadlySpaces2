using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CallbackInfo : Callbackable
{
    private GameObject _objectToCall;
    private string _methodName;
    
    public CallbackInfo(GameObject pObjectToCall,string pMethodName)
    {
        _objectToCall = pObjectToCall;
        _methodName = pMethodName;
    }

    public void Callback()
    {
        _objectToCall.SendMessage(_methodName);
    }
}

public interface Callbackable
{
    void Callback();
}

public class CallBackInfoWithAction : Callbackable
{
    private Action _callBackAction;
    private GameObject _gameObject;

    public CallBackInfoWithAction(GameObject gameObject, Action callbackAction)
    {
        _gameObject = gameObject;
        _callBackAction = callbackAction;
    }

    public void Callback()
    {
        if (_callBackAction != null && _gameObject != null)
        {
            _callBackAction();
        }
    }
}

public class TimingInfo
{
    public Callbackable CallBackInfo;
    public float Timer;
    
    public TimingInfo(Callbackable pCallBackInfo,float pTimer)
    {
        CallBackInfo = pCallBackInfo;
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

    public static void Start(float pDurationOfTimer,Callbackable pCallbackInfo)
    {
        mTimers.Add(new TimingInfo(pCallbackInfo, pDurationOfTimer));           
    }

    public static void Start(GameObject gameObject, float pDurationOfTimer, Action callBackAction)
    {
        Start(pDurationOfTimer, new CallBackInfoWithAction(gameObject, callBackAction));
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
            TimerCallBack(tTimingInfo.CallBackInfo);
            mTimers.Remove(tTimingInfo);
        }

        mTimersToBeDestroyed.Clear();
    }

    void TimerCallBack(Callbackable callback)
    {
       callback.Callback();
    }

    void CountDownTimers()
    {
        foreach(TimingInfo tTimingInfo in mTimers)
        {
            tTimingInfo.Timer -= Time.deltaTime;
        }
    }

   
	
}
