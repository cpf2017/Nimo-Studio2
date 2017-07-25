using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*****************************
创建时间：2017-7-3 9:14:26
创建人：夏洛克丶
邮箱：396070677@qq.com
微信：18500467616
网址：www.newbieol.com
公司名称：菜鸟在线
*****************************
*/
public class UIHandler : MonoBehaviour {

    //通过名字寻找子物体
    protected GameObject GetByName(string name)
    {
        Transform[] trans = GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < trans.Length; i++)
        {
            if (trans[i].name == name)
            {
                return trans[i].gameObject;
            }
        }
        return null;
    }

    // 泛型函数
    protected T GetComponentByName<T>(string name) where T : MonoBehaviour
    {
        GameObject go = GetByName(name);
        if (go == null)
        {
            return null;
        }
        return go.GetComponent<T>();
    }
}
