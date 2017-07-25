using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*****************************
创建时间：2017-7-3 13:55:22
创建人：夏洛克丶
邮箱：396070677@qq.com
微信：18500467616
网址：www.newbieol.com
公司名称：菜鸟在线
*****************************
*/
public class UIHouseItem : UIHandler {

    //house的图标
    private UIButton _houseSprite;
    public UIButton houseSprite
    {
        get { if (_houseSprite == null)
            {
                _houseSprite = this.GetComponent<UIButton>();
            }
            return _houseSprite;
        }

    }
    //title的图标
    private UISprite _titleSprite;
    public UISprite titleSprite
    {
        get
        {
            if (_titleSprite == null)
            {
                _titleSprite = GetByName("title").GetComponent<UISprite>();
            }
            return _titleSprite;
        }
    }

    // 用来标记当前阶段是否开启的状态
    private bool _lock;
    public bool Lock
    {
        get { return _lock; }
        set { _lock = value;
            titleSprite.gameObject.SetActive(!_lock);
            if (_lock)
            {
                houseSprite.normalSprite = "gray_dt_fz" + StageID;
            }
        }
    }

    //标记阶段的ID号
    private int _stageId = 1;
    public int StageID
    {
        get { return _stageId; }
        set {
            _stageId = value;
            houseSprite.normalSprite = "dt_fz" + _stageId;
            titleSprite.spriteName = "dt_wz" + _stageId;
        }

    }

    //初始化ID和状态
    public void InitHouseSprite(int stageId, bool islock = false)
    {
        this.StageID = stageId;
        this.Lock = islock;
    }

    //每个house的点击事件
    void OnClick()
    {
       
        if (!Lock)
        {
            GameConfig.instance.CurStageCount = (StageID+1);

            UIGameManager.instance.ShowUI(UIName.UIStage);
            UIGameManager.instance.HideUI(UIName.UIMap);
        }
        else
        {
            UIAlertManager.instance.CreateAlert(this.gameObject, "UIAlert",null,"消息", "请解锁上一关卡！");
        }
    }

}
