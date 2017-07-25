using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*****************************
创建时间：2017-6-30 10:39:32
创建人：夏洛克丶
邮箱：396070677@qq.com
微信：18500467616
网址：www.newbieol.com
公司名称：菜鸟在线
*****************************
*/
public class UIStageHandler : UIHandler {

    public UIButton btn_back;

    public int levelCount = 10;

    public GameObject itemPrefab = null;

    public UIGrid uigrid;

    public List<GameObject> ObjList = new List<GameObject>();
	void Start () {

        btn_back = GetByName("back_Btn").GetComponent<UIButton>();
        EventDelegate.Add(btn_back.onClick, Onbtnclick);


        itemPrefab = Resources.Load("UIPrefabs/Stage_Item") as GameObject;
        uigrid = GetByName("Grid").GetComponent<UIGrid>();

        UpdateShow();

        UIGameManager.instance.onUpdata += UpdateShow;

    }
    void UpdateShow()
    {
        for (int i = 0; i < ObjList.Count; i++)
        {
            Destroy(ObjList[i]);
        }
        ObjList.Clear();
        for (int i = 0; i < levelCount; i++)
        {
            GameObject Stage_item = NGUITools.AddChild(uigrid.gameObject, itemPrefab);
            ObjList.Add(Stage_item); 
            if (Stage_item != null)
            {
                UIStageItem item = Stage_item.AddComponent<UIStageItem>();
                item.ItemLabel.text = i + 1 + "";
                //将每个item状态修改为和枚举匹配的状态
                item.leveltype = (UIStageItem.LevelType)int.Parse(GameConfig.instance.GetStageData("stageData" + GameConfig.instance.CurStageCount)[i]);

                string[] info = GameConfig.instance.GetStageData("stageData" + GameConfig.instance.CurStageCount);

            }

        }
        //Grid执行排列
        uigrid.repositionNow = true;
    }

    void Onbtnclick()
    {
        UIGameManager.instance.ShowUI(UIName.UIMap);
        UIGameManager.instance.HideUI(UIName.UIStage);
    }


    void Update () {
		
	}
}
