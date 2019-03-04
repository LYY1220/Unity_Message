using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 消息处理中心
///      只负责消息的转发
///      ui-----消息发送中心-----具体的模块
/// </summary>
public class MsgCenter : MonoBase {

    public static MsgCenter Instance=null;

    private void Awake()
    {
        Instance = this;
        gameObject.AddComponent<AudioManager>();
        gameObject.AddComponent<UIManager>();
    }


    /// <summary>
    /// 发送消息
    ///     根据不同的模块发送给不同的模块,识别模块通过areaCode识别
    ///     识别事件,通过第二个参数，eventCode
    ///     触发的事件的参数，通过object类型进行接收
    /// </summary>
    public void Dispatch(int areaCode,int eventCode,object message)
    {
        switch (areaCode)
        {
            case AreaCode.UI:
                UIManager.Instance.Execute(eventCode, message);
                break;
            case AreaCode.AUDIO:
                Debug.Log("msgcenter");
                AudioManager.Instance.Execute(eventCode, message);
                break;
            case AreaCode.CHARACTER:
                break;
            case AreaCode.GAME:
                break;
            case AreaCode.NET:
                break;
          
            default:
                break;
        }
    }
}
