using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*****************************
创建时间：2017-6-30 10:5:25
创建人：夏洛克丶
邮箱：396070677@qq.com
微信：18500467616
网址：www.newbieol.com
公司名称：菜鸟在线
*****************************
*/
public class UIGame  {

    //UI物体对象
    public GameObject UIObj;

    //UI名字
    public string Name
    {
        get {return UIObj.name; }
    }
    //UI是否显示
    public bool Visible
    {
        get { return UIObj.activeInHierarchy; }
        set { UIObj.SetActive(value); }
    }
    //构建UI
    public UIGame(string name)
    {
        UIObj = GameObject.Instantiate(Resources.Load("UI/" + name)) as GameObject;
        if (UIObj != null)
        {
            UIObj.name = name;
            UIObj.AddComponent(System.Type.GetType(name + "Handler"));
            UIObj.SetActive(false);

        }
    }
}
