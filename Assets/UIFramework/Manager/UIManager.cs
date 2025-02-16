using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//****************************************
//创建人：逸龙
//功能说明：
//****************************************
public class UIManager
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }
    private Transform canvasTransform;
    private Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
            {
                canvasTransform = GameObject.Find("Canvas").transform;
            }
            return canvasTransform;
        }
    }
    private Dictionary<UIPanelType, string> panelPathDict;//存储所有的面板预制体的路径
    private Dictionary<UIPanelType, BasePanel> panelDict;//保存所有已实例化的面板的游戏物体身上的BasePanel组件
    private Stack<BasePanel> panelStack;
    private UIManager()
    {
        ParseUIPanelTypeJson();
    }
    [Serializable]
    class UIPanelTypeJson
    {
        public List<UIPanelInfo> infoList;
    }
    /// <summary>
    /// 把某个页面入栈，显示页面
    /// </summary>
    /// <param name="panelType"></param>
    public void PushPanel(UIPanelType panelType)
    {
        if (panelStack == null) panelStack = new Stack<BasePanel>();

        if (panelStack.Count > 0)
        {
            BasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }
        BasePanel panel = GetPanel(panelType);
        panel.OnEnter();
        panelStack.Push(panel);
    }
    /// <summary>
    /// 出栈，隐藏页面
    /// </summary>
    public void PopPanel()
    {
        if (panelStack == null) panelStack = new Stack<BasePanel>();
        if (panelStack.Count <= 0) return;
        //关闭栈顶页面的显示
        BasePanel topPanel = panelStack.Pop();
        topPanel.OnExit();
        if (panelStack.Count <= 0) return;
        BasePanel topPanel2 = panelStack.Peek();
        topPanel2.OnResume();
    }
    /// <summary>
    /// 根据面板类型 得到实例化的面板
    /// </summary>
    /// <param name="panelType"></param>
    /// <returns></returns>
    private BasePanel GetPanel(UIPanelType panelType)
    {
        if (panelDict == null)
        {
            panelDict = new Dictionary<UIPanelType, BasePanel>();
        }
        //BasePanel panel;
        //panelDict.TryGetValue(panelType, out panel);
        BasePanel panel = panelDict.TryGet(panelType);
        if (panel == null)
        {
            //string path;
            //panelPathDict.TryGetValue(panelType, out path);
            string path = panelPathDict.TryGet(panelType);
            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instPanel.transform.SetParent(CanvasTransform, false);
            panelDict.Add(panelType, instPanel.GetComponent<BasePanel>());
            return instPanel.GetComponent<BasePanel>();
        }
        else
        {
            return panel;
        }

    }
    /// <summary>
    /// 解析UI面板的json（使用unity自带的JsonUtility）
    /// </summary>
    private void ParseUIPanelTypeJson()
    {
        panelPathDict = new Dictionary<UIPanelType, string>();
        TextAsset ta = Resources.Load<TextAsset>("UIPanelType");
        UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);
        foreach (UIPanelInfo info in jsonObject.infoList)
        {
            panelPathDict.Add(info.panelType, info.path);
        }
    }
    public void Test()
    {
        Debug.Log("1");
        Debug.Log(panelPathDict.Count);
    }
}