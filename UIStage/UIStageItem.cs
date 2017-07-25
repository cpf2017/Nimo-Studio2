using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*****************************
创建时间：2017-7-12 10:4:7
创建人：夏洛克丶
邮箱：396070677@qq.com
微信：18500467616
网址：www.newbieol.com
公司名称：菜鸟在线
*****************************
*/
public class UIStageItem : UIHandler {

    private UISprite _itemSprite;
    public UISprite ItemSprite   //StageItem自身的UISprite
    {
        get { if (_itemSprite == null)
            {
                _itemSprite = this.GetComponent<UISprite>();
            }
            return _itemSprite;
        }
    }

    private UILabel _itemLabel;
    public UILabel ItemLabel   //stageItem下的UILabel
    {
        get
        {
            if (_itemLabel == null)
            {
                _itemLabel = this.GetComponentInChildren<UILabel>();
            }
            return _itemLabel;
        }

    }

    private GameObject _star;
    public GameObject star   //stageItem下的星星
    {
        get
        {
            if (_star == null)
            {
                _star = GetByName("star_fg0");
            }
            return _star;
        }
    }


    //所选择的关卡(Level)数

    private int _levelindex = 1;
    public int LevelIndex
    {
        get { return _levelindex; }
        set { _levelindex = value;

        }
        
    }




    //关卡的状态枚举
    public enum LevelType
    {
        LOCK = 0,     //锁定
        CURRENT = 1,  //当前可玩
        PASS = 2,     //过关
    }
    private LevelType _leveltype;
    public LevelType leveltype
    {
        get { return _leveltype; }
        set
        {
            _leveltype = value;
            switch (_leveltype)
            {
                case LevelType.LOCK:
                    // 锁定状态
                    ItemSprite.spriteName = "gq_paizi_hui";
                    ItemLabel.gameObject.SetActive(false);
                    star.SetActive(false);

                    break;
                case LevelType.CURRENT:
                    // 当前状态
                    ItemSprite.spriteName = "gq_paizi_sel";
                    ItemLabel.gameObject.SetActive(true);
                    star.SetActive(false);

                    break;
                case LevelType.PASS:
                    // 过关状态
                    ItemSprite.spriteName = "gq_paizi_sel";
                    ItemLabel.gameObject.SetActive(true);
                    star.SetActive(true);
                    break;

            }

        }



    }

    void OnClick()
    {
        if (leveltype == LevelType.LOCK)
        {
           
           
            //生成Alert
            UIAlertManager.instance.CreateAlert(this.gameObject, "UIAlert",null,"消息", "请完成上一关卡！");
        }

        else
        {
            //当前关卡索引赋值
            LevelIndex = int.Parse(ItemLabel.text);
            GameConfig.instance.CurLevelCount = LevelIndex;
            //跳转界面 
            UIGameManager.instance.ShowUI(UIName.UILevel);
            UIGameManager.instance.HideUI(UIName.UIStage);
        }
    }
}
