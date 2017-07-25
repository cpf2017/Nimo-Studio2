using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*****************************
创建时间：2017-7-13 9:40:9
创建人：夏洛克丶
邮箱：396070677@qq.com
微信：18500467616
网址：www.newbieol.com
公司名称：菜鸟在线
*****************************
*/
public class UIChater : MonoBehaviour {

    private UILabel _chaterLabel;   //点击的字体
    public UILabel ChaterLabel
    {
        get { if (_chaterLabel == null)
            {
                _chaterLabel = this.GetComponentInChildren<UILabel>();
            }
            return _chaterLabel;
        }
    }
   
    public string text  //点击的文本内容
    {
        get { return ChaterLabel.text; }
        set { ChaterLabel.text = value; }
            
       
    }

    void OnClick()
    {
       
        for (int i = 0; i < UIResultListHandler.instance.Result_Labels.Length; i++)
        {
            if (UIResultListHandler.instance.Result_Labels[i].text == "")
            {
                UIResultListHandler.instance.Result_Labels[i].text = this.text;
                this.gameObject.SetActive(false);
                break;
            }
        }

        if (UIChaterManager.instance.ChaterList.Count >= 4)
        {
            return;
        }
        else
        {
            UIChaterManager.instance.ChaterList.Add(this);
        }
        UIChaterManager.instance.OnSubmitChar();
        
    } 


}
