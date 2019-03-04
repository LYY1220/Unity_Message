using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 案例代码
/// </summary>
public class MainAudioCtrl : AudioBase {

    private void Awake()
    {
        //事件的关心者
        Bind(AudioEvent.PLAY_AUDIO);
    }
    /// <summary>
    /// 编写事件触发的函数
    /// </summary>
    /// <param name="eventCode"></param>
    /// <param name="message"></param>
    public override void Execute(int eventCode, object message)
    {
        Debug.Log(eventCode);
        switch (eventCode)
        {
            case AudioEvent.PLAY_AUDIO:
                Debug.Log("我听到了消息："+message);
                break;                                  
            default:
                break;
        }
    }
}
