using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
/*
*****************************
创建时间：2017-7-12 15:50:39
创建人：夏洛克丶
邮箱：396070677@qq.com
微信：18500467616
网址：www.newbieol.com
公司名称：菜鸟在线
*****************************
*/
public class UILevelHandler : UIHandler {

    public UISprite bfaceSprite;
    public UISprite player_title;
    public UILabel stage_Label;
    public UITexture reddle_textrue;
    public UILabel coin_number;


    public UILevelData leveldata;

    public TextAsset textasset;

    public int ChartItemCount = 18;  //需要生成的ChartItem数量 
    public UIGrid grid; //用来排列的UIGrid
    public UIChater[] UIChaters = new UIChater[18];
    public List<GameObject> ChatObjList = new List<GameObject>();

    public UIButton btn_back;
    private void Start()
    {
        bfaceSprite = GetComponentByName<UISprite>("bface");
        player_title = GetComponentByName<UISprite>("Player_title");
        stage_Label = GetComponentByName<UILabel>("stage_Label");
        reddle_textrue = GetComponentByName<UITexture>("reddle_textrue");
        coin_number = GetComponentByName<UILabel>("coin_number");
        grid = GetComponentByName<UIGrid>("ChaterGrid");
        btn_back = GetComponentByName<UIButton>("back_Btn");
        EventDelegate.Add(btn_back.onClick, OnBackClick);
        UpdateShow();
        UIGameManager.instance.onUpdata += UpdateShow;

    }
    void OnBackClick()
    {
        UIGameManager.instance.ShowUI(UIName.UIStage);
        UIGameManager.instance.HideUI(UIName.UILevel);
    }
    private void UpdateShow()
    {
        bfaceSprite.spriteName = "bface_" + (GameConfig.instance.MaxStageCount - 1);
        player_title.spriteName = "levelname_" + (GameConfig.instance.MaxStageCount - 1);
        //阶段数和关卡数显示，这里还可以用来作为读取json文本的路径使用
        stage_Label.text = "stage" + GameConfig.instance.CurStageCount + "_" + GameConfig.instance.CurLevelCount;

        textasset = Resources.Load<TextAsset>("json/"+ stage_Label.text);  //获取json文本
       
        leveldata = JsonMapper.ToObject<UILevelData>(textasset.text);  //json文本内容转换为UILevelData
        print(stage_Label.text);                                                              //将question1.png替换为question1
        Texture temptexture = Resources.Load<Texture>("images/" + (leveldata.image.Replace(".png", "")));
        reddle_textrue.mainTexture = temptexture;

        coin_number.text = (int.Parse(coin_number.text) + leveldata.coin).ToString();
        LoadChater();
    }

    //加载并随机生成汉字
    void LoadChater()
    {
        //重置操作
        for (int i = 0; i < ChatObjList.Count; i++)
        {
            Destroy(ChatObjList[i].gameObject);
        }
        for (int i = 0; i < UIResultListHandler.instance.Result_Labels.Length; i++)
        {
            UIResultListHandler.instance.Result_Labels[i].text = "";
        }
        ChatObjList.Clear();
        UIChaterManager.instance.ChaterList.Clear();

        //获取随意字符
        string[] charArray = UIChaterManager.instance.InitCharter(leveldata.title);

        UIChaterManager.instance.onComponent += Instance_onComponent;

        for (int i = 0; i < ChartItemCount; i++)
        {
            UIChaters[i] = NGUITools.AddChild(grid.gameObject, (GameObject)Resources.Load("UIPrefabs/ChaterItem")).GetComponent<UIChater>();
            UIChaters[i].text = charArray[i];
            ChatObjList.Add(UIChaters[i].gameObject);
            //将初始时，透明度改为0
            UISprite sp = UIChaters[i].GetComponent<UISprite>();
            Color c = sp.color;
            c.a = 0;
            sp.color = c;


            //添加缩放效果
            TweenScale ts = UIChaters[i].gameObject.AddComponent<TweenScale>();
            ts.from = new Vector3(1.5f, 1.5f, 1.5f);
            ts.to = Vector3.one;
            ts.duration = 0.05f;
            ts.delay = 0.1f * i;
            ts.PlayForward();

            //添加透明度效果
            TweenAlpha ta = UIChaters[i].gameObject.AddComponent<TweenAlpha>();
            ta.from = 0;
            ta.to = 1;
            ta.duration = 0.05f;
            ta.delay = 0.1f * i;
            ta.PlayForward();
        }
        grid.repositionNow = true;
    }

    //答案选择完成后的事件
    private void Instance_onComponent(string param)
    {
        if (param == leveldata.title)
        {
          

            UIAlertManager.instance.CreateAlert(this.gameObject, "UIPassPad", PassLevel, leveldata.desc, leveldata.orgin, leveldata.title);
        }
        else
        {
          

            UIAlertManager.instance.CreateAlert(this.gameObject, "UIAlert", null, "消息", "回答错误，请继续努力！");
        }
    }
    //完成每过一小关需要执行的函数
    private void PassLevel()
    {
        string[] info = GameConfig.instance.GetStageData("stageData" + GameConfig.instance.CurStageCount);
      
        info[GameConfig.instance.CurLevelCount-1] = "2";

        GameConfig.instance.CurLevelCount += 1;
        //完成所有关卡
        if (GameConfig.instance.CurLevelCount > 10)
        {      //当前选择的阶段是否大于最大可玩阶段数（小于表示已经通关，无需更新）
            if (GameConfig.instance.CurStageCount >= GameConfig.instance.MaxStageCount)
            {
                GameConfig.instance.CurLevelCount = 1;
                //当前阶段曾一个
                GameConfig.instance.MaxStageCount = GameConfig.instance.CurStageCount + 1;
                //更新现阶段数据
                string[] nextInfo = GameConfig.instance.GetStageData("stageData" + GameConfig.instance.MaxStageCount);
                //解锁新阶段第一个关卡
                nextInfo[GameConfig.instance.CurLevelCount - 1] = "1";
                //保存更新的内容
                GameConfig.instance.SetStageData("stageData" + (GameConfig.instance.CurStageCount + 1), nextInfo);
                //显示UIAlet返回UIMap
                UIAlertManager.instance.CreateAlert(this.gameObject, "UIAlert", BackUIMap, "消息", "恭喜通过了第" + GameConfig.instance.CurStageCount + "关");
            }
            else
            {
                //重置关卡数
                GameConfig.instance.CurLevelCount = 1;
                //显示UIAlet返回UIMap
                UIAlertManager.instance.CreateAlert(this.gameObject, "UIAlert", BackUIMap, "消息", "恭喜通过了第" + GameConfig.instance.CurStageCount + "关");
               
            }
            

        }
        else
        {
            info[GameConfig.instance.CurLevelCount -1] = "1";
            //更新显示
            UpdateShow();
        }
        //保存已经通关的内容
        GameConfig.instance.SetStageData("stageData" + (GameConfig.instance.CurStageCount), info);
    }

    private void BackUIMap()
    {
        UIGameManager.instance.ShowUI(UIName.UIMap);
        UIGameManager.instance.HideUI(UIName.UILevel);
       
    }
}


