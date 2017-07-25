using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*****************************
创建时间：2017-7-3 14:36:13
创建人：夏洛克丶
邮箱：396070677@qq.com
微信：18500467616
网址：www.newbieol.com
公司名称：菜鸟在线
*****************************
*/
public class GameConfig  {

    private static GameConfig _instance;
    public static GameConfig instance
    {
        get {
            if (_instance == null)
            {
                _instance = new GameConfig();
            }
            return _instance;
        
        }
    }

    public bool isLocal = true;

     

    //当前最大StageCount
    private int _MaxStageCount = 1;
    public int MaxStageCount
    {
        get {
            if (!PlayerPrefs.HasKey("CurStage"))
            {
                PlayerPrefs.SetInt("CurStage", 1);
            }
            _MaxStageCount = PlayerPrefs.GetInt("CurStage");
            return _MaxStageCount;
        }

        set
        {
            _MaxStageCount = value;
            //玩家偏好
            PlayerPrefs.SetInt("CurStage", _MaxStageCount);
        }

    }

    // 当前的关卡数
    public int CurLevelCount =1;
    //当前可选择的阶段数
    public int CurStageCount = 1;

    //第一阶段关卡信息
    private string[] _stageData1;
    public string[] stageData1
    {
        get
        {
            if (!PlayerPrefs.HasKey("stageData1"))
            {
                PlayerPrefs.SetString("stageData1", "1,0,0,0,0,0,0,0,0,0");
            }
            _stageData1 = PlayerPrefs.GetString("stageData1").Split(',');
            return _stageData1;
        }

        set
        {
            _stageData1 = value;
            //玩家偏好
            PlayerPrefs.SetString("stageData1", string.Join(",",_stageData1));
        }
    }
    //第二阶段关卡信息
    private string[] _stageData2;
    public string[] stageData2
    {
        get
        {
            if (!PlayerPrefs.HasKey("stageData2"))
            {
                PlayerPrefs.SetString("stageData2", "0,0,0,0,0,0,0,0,0,0");
            }
            _stageData2 = PlayerPrefs.GetString("stageData2").Split(',');
            return _stageData2;
        }

        set
        {
            _stageData2 = value;
            //玩家偏好
            PlayerPrefs.SetString("stageData2", string.Join(",", _stageData2));
        }
    }
    //第三阶段关卡信息
    private string[] _stageData3;
    public string[] stageData3
    {
        get
        {
            if (!PlayerPrefs.HasKey("stageData3"))
            {
                PlayerPrefs.SetString("stageData3", "0,0,0,0,0,0,0,0,0,0");
            }
            _stageData3 = PlayerPrefs.GetString("stageData3").Split(',');
            return _stageData3;
        }

        set
        {
            _stageData3 = value;
            //玩家偏好
            PlayerPrefs.SetString("stageData3", string.Join(",", _stageData3));
        }
    }
    //第四阶段关卡信息
    private string[] _stageData4;
    public string[] stageData4
    {
        get
        {
            if (!PlayerPrefs.HasKey("stageData4"))
            {
                PlayerPrefs.SetString("stageData4", "0,0,0,0,0,0,0,0,0,0");
            }
            _stageData4 = PlayerPrefs.GetString("stageData4").Split(',');
            return _stageData4;
        }

        set
        {
            _stageData4 = value;
            //玩家偏好
            PlayerPrefs.SetString("stageData4", string.Join(",", _stageData4));
        }
    }
    //存储所有阶段数据
    public Dictionary<string, string[]> stageInfo = new Dictionary<string, string[]>();
    public void InitStageInfo()
    {
        stageInfo.Add("stageData1", stageData1);
        stageInfo.Add("stageData2", stageData2);
        stageInfo.Add("stageData3", stageData3);
        stageInfo.Add("stageData4", stageData4);
    }
    //通过name（Key）获取该阶段数据
    public string[] GetStageData(string name)
    {
        string[] info;

        stageInfo.TryGetValue(name, out info);

        return info;

    }
    //通过name（Key）保存该阶段数据
    public void SetStageData(string name,string[] value)
    {
        PlayerPrefs.SetString(name, string.Join(",", value));
    }

}
