using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//****************************************
//创建人：逸龙
//功能说明：
//****************************************
[Serializable]
public class UIPanelInfo : ISerializationCallbackReceiver
{
    [NonSerialized]
    public UIPanelType panelType;
    public string panelTypeString;
    //{
    //    get { return panelType.ToString(); }
    //    set { panelType = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), value); }
    //}
    public string path;
    /// <summary>
    /// 反序列化时调用
    /// </summary>
    public void OnAfterDeserialize()
    {
        panelType = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeString);
    }
    /// <summary>
    /// 序列化时调用
    /// </summary>
    public void OnBeforeSerialize()
    {
        
    }
}
