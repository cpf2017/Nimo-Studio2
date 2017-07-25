using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*****************************
创建时间：2017-6-30 10:13:2
创建人：夏洛克丶
邮箱：396070677@qq.com
微信：18500467616
网址：www.newbieol.com
公司名称：菜鸟在线
*****************************
*/
public class UIGameManager
{

    //单例模式
    private UIGameManager()
    {
    }
    private static UIGameManager _instance;
    public static UIGameManager instance
    {
        get {
            if (_instance == null)
            {
                _instance = new UIGameManager();
            }
            return _instance;
        }
    }

    public delegate void OnUpdataShow();
    public OnUpdataShow onUpdata;
    

    List<UIGame> UIGameList = new List<UIGame>();
    //添加UI到列表
    public void AddUI(string name,bool visible = false)
    {
        UIGame gui = new UIGame(name);
        if (gui != null)
        {
            gui.Visible = visible;
            UIGameList.Add(gui);
        }
    }
    //通过名字寻找列表里的UI
    UIGame GetByUIGame(string name)
    {
        for (int i = 0; i < UIGameList.Count; i++)
        {
            if (UIGameList[i].Name == name)
            {
                return UIGameList[i];
            }
        }
        return null;
    }
    // 显示UI
    public void ShowUI(string name)
    {
        UIGame gui = GetByUIGame(name);
        if (gui != null)
        {
            gui.Visible = true;
            if (onUpdata != null)
            {
                onUpdata();
            }
        }
    }
    // 隐藏UI
    public void HideUI(string name)
    {
        UIGame gui = GetByUIGame(name);
        if (gui != null)
        {
            gui.Visible = false;
        }
    }


}
