/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年09月03日 17:04:55
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TamToast : SingletonMono<TamToast>
{
    //单独的画布
    private Canvas _tipsCanvas;
    //储存所有提示文字节点
    private Transform _tipsBase;

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// 初始化对象池 加载节点
    /// </summary>
    private void Init()
    {
        //因为提示文字要显示在所有层级的最上方 我这里在场景新建一个Canvas
        _tipsCanvas = this.LoadTipPrefab().GetComponent<Canvas>();
        _tipsCanvas.sortingOrder = 100;
        _tipsCanvas.transform.SetParent(this.transform);
        //新建一个节点储存所有显示的Tip
        _tipsBase = _tipsCanvas.transform.Find("TipsBase");

        GameObject tmpMessageBox = Resources.Load<GameObject>("Prefab/Toast/MessageTip");

        //初始化对象池
        TamToastPool.Instance.InitPool(PoolType.TEXTTIP, tmpMessageBox, 10);
    }

    /// <summary>
    /// 加载做好的预制体(根据项目来 一般都是打成ab包 我这里方便展示就不写了)
    /// </summary>
    /// <returns></returns>
    private GameObject LoadTipPrefab()
    {
        //我是把这个Canvas做成了预制体放在了 这个目录下
        return Instantiate(Resources.Load<GameObject>("Prefab/Toast/MessageCanvas"));
    }

    public static void GenerateToast(string str, float stayTime = 2f, float moveY = 80f)
    {
        if (Instance != null)
        {
            Instance.GenerateMessage1(str, stayTime, moveY);
        }
    }

    /// <summary>
    /// 提示文字 系统消息
    /// </summary>
    /// <param name="str">提示内容</param>
    /// <param name="stayTime">停留几秒</param>
    /// <param name="moveY">向上飞多高(根据你提示框的高度自定义)</param>
    public void GenerateMessage1(string str, float stayTime = 2f, float moveY = 80f)
    {
        //第一次调用先初始化池子
        if (_tipsCanvas == null) this.Init();
        //先判断当前节点下是不是有提示文字 如果有渐隐
        int indexcount = 0;
        if (this._tipsBase.childCount > 3)
        {
            indexcount = this._tipsBase.childCount - 3;
            foreach (Transform childNode in this._tipsBase)
            {
                indexcount--;
                childNode.GetComponent<CanvasGroup>().DOFade(0f, 0.25f);
                if (indexcount <= 0) break;
            }
        }

        ;
        //让原来的提示向上滚 
        foreach (RectTransform childNode in this._tipsBase)
        {
            //Debug.Log("LayoutUtility.GetPreferredHeight	(childNode): " + LayoutUtility.GetPreferredHeight(childNode));
            childNode.DOLocalMoveY(childNode.localPosition.y + moveY, 0.3f); //childNode.sizeDelta.y
        }
        //创建新的提示文字       (这里用到了对象池 你们也可以自己克隆出来那个预制体)
        RectTransform tipObj = TamToastPool.Instance.Get(PoolType.TEXTTIP).GetComponent<RectTransform>();
        tipObj.SetParent(_tipsBase);
        tipObj.localPosition = Vector3.zero;
        tipObj.gameObject.SetActive(true);
        //tipObj.GetComponentInChildren<Text>().text = str;
        tipObj.GetComponentInChildren<Text>().DOText(str, 1);
        //判断是否刚显示过一个
        float aTime = this._tipsBase.childCount == 1 ? 0f : 0.3f;
        //利用Dotween做动画
        Sequence sequence = DOTween.Sequence();
        //sequence.Insert (aTime, tipObj.GetComponent<CanvasGroup> ().DOFade (1, 0.2f));
        sequence.Append(tipObj.GetComponent<CanvasGroup>().DOFade(1, 0.2f));
        sequence.AppendInterval(stayTime + aTime);
        sequence.Append(tipObj.GetComponent<CanvasGroup>().DOFade(0, 0.8f));
        //动画结束后回收
        sequence.OnComplete(() =>
        {
            TamToastPool.Instance.Put(PoolType.TEXTTIP, tipObj.gameObject);
        });
        sequence.Play();
    }
}