using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*****************************
创建时间：2017-7-3 13:36:52
创建人：夏洛克丶
邮箱：396070677@qq.com
微信：18500467616
网址：www.newbieol.com
公司名称：菜鸟在线
*****************************
*/
public class UIAlertManager {

    private UIAlertManager()
    {

    }

    private static UIAlertManager _instance;
    public static UIAlertManager instance
    {
        get { if (_instance == null)
            {
                _instance = new UIAlertManager();
            }
            return _instance;
        }
    }

    List<GameObject> AlertList = new List<GameObject>();



    public void CreateAlert(GameObject parent,string prefabName,System.Action action = null,params string[] param)
    {
        for (int i = 0; i < AlertList.Count; i++)
        {
            GameObject.Destroy(AlertList[i]);
        }

        GameObject AlertPrefab = NGUITools.AddChild(parent, (GameObject)Resources.Load("UIPrefabs/" + prefabName)) as GameObject;
        switch (prefabName)
        {
            case "UIAlert":
                UIAlert Alert = AlertPrefab.AddComponent<UIAlert>();
                if (Alert != null)
                {
                    Alert.ShowAlert(param[0], param[1],action);
                    AlertList.Add(Alert.gameObject);
                }
                break;
            case "UISetting":
                //to do //点击设置按钮显示的Alert
                //UISetting Setting = AlertPrefab.AddComponent<UIAlert>();
                //if (Setting != null)
                //{
                //    Setting.ShowAlert();
                //}
                break;
            case "UIPassPad":

                UIPasspad Passpad = AlertPrefab.AddComponent<UIPasspad>();
                if (Passpad != null)
                {
                    Passpad.ShowPassPad(param[0], param[1], param[2], action);
                    AlertList.Add(Passpad.gameObject);
                }


                break;
        }
    }
}
