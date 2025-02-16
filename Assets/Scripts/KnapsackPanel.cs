using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//****************************************
//创建人：逸龙
//功能说明：
//****************************************
public class KnapsackPanel : BasePanel
{
    private void Awake()
    {
        base.Awake();
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }
    public override void OnPause()
    {
        base.OnPause();
    }
    public override void OnResume()
    {
        base.OnResume();
    }
    public override void OnExit()
    {
        base.OnExit();
    }
    public void OnItemButton()
    {
        UIManager.Instance.PushPanel(UIPanelType.ItemMessage);
    }
}
