using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*****************************
创建时间：2017-7-20 13:45:20
创建人：夏洛克丶
邮箱：396070677@qq.com
微信：18500467616
网址：www.newbieol.com
公司名称：菜鸟在线
*****************************
*/
public class UIPasspad : UIHandler {

    public UILabel explain1;
    public UILabel explain2;
    public UILabel title_Label;

    public UIButton Next_Btn;

    System.Action _Action;
    //public delegate void OnComponent();
    //public event OnComponent onComponent;

    void Awake ()
    {
        explain1 = GetComponentByName<UILabel>("explain 1");
        explain2 = GetComponentByName<UILabel>("explain 2");
        title_Label = GetComponentByName<UILabel>("title_Label");
        Next_Btn = GetComponentByName<UIButton>("Next");
        EventDelegate.Add(Next_Btn.onClick, OnNextClick);
    }
    void OnNextClick()
    {

            if (_Action != null)
            {
                _Action();
            }
            GameObject.Destroy(this.gameObject); 
    }

    public void ShowPassPad(string text1,string text2,string text3, System.Action action = null )
    {
        explain1.text = text1;
        explain2.text = text2;
        title_Label.text = text3;
        this._Action  += action;
    }
	
	
}
