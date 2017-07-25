using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/*
*****************************
创建时间：2017-7-13 9:36:5
创建人：夏洛克丶
邮箱：396070677@qq.com
微信：18500467616
网址：www.newbieol.com
公司名称：菜鸟在线
*****************************
*/
public class UIChaterManager  {

    private UIChaterManager()
    {

    }
    private static UIChaterManager _instance;
    public static UIChaterManager instance
    {
        get { if (_instance == null)
            {
                _instance = new UIChaterManager();
            }
            return _instance;
        }
    }

    //满足4个字时提交答案的事件
    public delegate void onCharComponent(string param);
    public event onCharComponent onComponent;

    //存放选中的字列表
    public List<UIChater> ChaterList = new List<UIChater>();

    

    //初始化生成18个字
    public string[] InitCharter(string solution)
    {
        

        TextAsset charText = Resources.Load<TextAsset>("character/characters");
        string[] AllcharArray = new string[charText.text.Length];
        for (int i = 0; i < AllcharArray.Length; i++)
        {
            AllcharArray[i] = charText.text[i].ToString();
        }
        RandomArray(AllcharArray);

        string[] newCharArray = new string[18];
        Array.Copy(AllcharArray, newCharArray, 14);
        for (int i = 0; i < solution.Length; i++)
        {
            newCharArray[14 + i] = solution[i].ToString();
        }

        RandomArray(newCharArray);

        return newCharArray;
    }

    //打乱数组里的字
    void RandomArray(string[] chars)
    {
        for (int i = 0; i < chars.Length; i++)
        {
            string temp = chars[i];
            int randomNum = UnityEngine.Random.Range(i, chars.Length);
            chars[i] = chars[randomNum];
            chars[randomNum] = temp;
        }
    }

    //当提交的字超过4个才会进行
    public void OnSubmitChar()
    {
        string param = "";
        for (int i = 0; i < UIResultListHandler.instance.Result_Labels.Length; i++)
        {
            //注意这里用列表里的字比较会有问题，列表添加元素有先后顺序。所以改用直接和UILabel中的text比较
            param += UIResultListHandler.instance.Result_Labels[i].text;
           
            
        }  

        if (ChaterList.Count >= 4)
        {
            if (onComponent != null)
            {
                onComponent(param);
            }
        }

    }
}
