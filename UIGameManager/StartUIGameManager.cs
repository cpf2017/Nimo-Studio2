using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*****************************
创建时间：2017-6-30 10:24:39
创建人：夏洛克丶
邮箱：396070677@qq.com
微信：18500467616
网址：www.newbieol.com
公司名称：菜鸟在线
*****************************
*/
public class StartUIGameManager : MonoBehaviour {

    public UIGameManager uimgr;
	void Awake ()
    {
        uimgr = UIGameManager.instance;
	}
    void Start()
    {


        uimgr.AddUI(UIName.UIHome, true);
        uimgr.AddUI(UIName.UIMap);
        uimgr.AddUI(UIName.UIStage);
        uimgr.AddUI(UIName.UILevel);


        GameConfig.instance.InitStageInfo();
      
    }
	// Update is called once per frame
	void Update () {
		
	}
}
