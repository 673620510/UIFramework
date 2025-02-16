using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//****************************************
//创建人：逸龙
//功能说明：
//****************************************
public class BasePanel : MonoBehaviour
{
    protected CanvasGroup canvasGroup;

    protected void Awake()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
    }
    /// <summary>
    /// 界面被显示出来
    /// </summary>
    public virtual void OnEnter()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        transform.localScale = new Vector3(0.1f,0.1f,0.1f);
        transform.DOScale(1, 0.2f);
    }
    /// <summary>
    /// 界面暂停
    /// </summary>
    public virtual void OnPause()
    {
        canvasGroup.blocksRaycasts = false;//弹出新面板时，让主菜单面板不再和鼠标进行交互
    }
    /// <summary>
    /// 界面继续
    /// </summary>
    public virtual void OnResume()
    {
        canvasGroup.blocksRaycasts = true;
    }
    /// <summary>
    /// 界面不显示，退出界面，界面被关闭
    /// </summary>
    public virtual void OnExit()
    {
        transform.DOScale(0.1f, 0.2f).OnComplete(() => { canvasGroup.alpha = 0; });
        //canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
    public virtual void OnClosePanel()
    {
        UIManager.Instance.PopPanel();
    }
}
