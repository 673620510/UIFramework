using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//****************************************
//创建人：逸龙
//功能说明：
//****************************************
public class GameRoot : MonoBehaviour
{
    private void Start()
    {
        UIManager.Instance.PushPanel(UIPanelType.MainMenu);
    }
}
