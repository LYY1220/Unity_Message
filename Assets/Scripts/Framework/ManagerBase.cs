using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 每一个模块的基类
///         1.保存自身注册的一系列的消息
/// </summary>
public class ManagerBase : MonoBase {

    /// <summary>
    /// 存储事件消息码哪一个脚本进行关联
    /// </summary>
    private Dictionary<int, List<MonoBase>> dict = new Dictionary<int, List<MonoBase>>();

    /// <summary>
    /// 处理自身的事件
    /// </summary>
    /// <param name="eventCode"></param>
    /// <param name="message"></param>
    public override void Execute(int eventCode, object message)
    {
        if(!dict.ContainsKey(eventCode))
        {
            Debug.LogWarning("事件没有注册");
            return;
        }
        List<MonoBase> list = dict[eventCode];
        for (int i = 0; i < list.Count; i++)
        {
            list[i].Execute(eventCode, message);
        }
    }

    public void Add(int eventCode,MonoBase mono)
    {
        List<MonoBase> list = null;
        if(!dict.ContainsKey(eventCode))
        {
            list = new List<MonoBase>();
            list.Add(mono);
            dict.Add(eventCode, list);
            return;
        }
        list = dict[eventCode];
        list.Add(mono);
    }

    /// <summary>
    /// 一个脚本添加多个事件码
    /// </summary>
    /// <param name="eventCode"></param>
    public void Add(int[] eventCode,MonoBase mono)
    {
        for (int i = 0; i < eventCode.Length; i++)
        {
            Add(eventCode[i], mono);
        }
    }

    public void Remove(int eventCode,MonoBase mono)
    {
        if(dict.ContainsKey(eventCode))
        {
            Debug.LogWarning("没有注册事件" + eventCode);
            return;
        }
        List<MonoBase> list = dict[eventCode];
        if (list.Count == 1)
            dict.Remove(eventCode);
        else
            list.Remove(mono);
    }

    public void Remove(int[] eventCode, MonoBase mono)
    {
        for (int i = 0; i < eventCode.Length; i++)
        {
            Remove(eventCode[i], mono);
        }
    }
}
