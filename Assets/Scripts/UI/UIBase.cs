using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBase
{

    /// <summary>
    /// 自身关心的消息集合
    /// </summary>
    List<int> list = new List<int>();

    protected void Bind(params int[] eventCode)
    {
        list.AddRange(eventCode);
        UIManager.Instance.Add(list.ToArray(), this);
    }

    protected void UnBind()
    {
        UIManager.Instance.Remove(list.ToArray(), this);
        list.Clear();
    }

    public void OnDestroy()
    {
        if (list != null)
        {
            UnBind();
        }
    }

    public virtual void Dispatch(int areaCode, int eventCode, object message)
    {
        MsgCenter.Instance.Dispatch(areaCode, eventCode, message);
    }
}
