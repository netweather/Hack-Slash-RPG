using UnityEngine;
using System.Collections;
using System;

public class GameSettings : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(this);
      //  [载入时不移除](这个脚本)
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SaveCharacterData()     //[保存角色数据]
    {
        //*********保存游戏名字***********
        GameObject pc = GameObject.Find("pc");
        //游戏对象 pc = 游戏对象.查找"pc"

        PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();
        //
       // PlayerPrefs.DeleteAll(); //删除所有的数据

        PlayerPrefs.SetString("Player Name", pcClass.Name);
        //[玩家设定.设置字符串("名称",值)]
        //*********保存游戏名字***********

        //*********保存游戏的基础值和经验值***********
        for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++)        //遍历属性名字
        {
            PlayerPrefs.SetInt(((AttributeName)cnt).ToString()+"- Base Value", pcClass.GetPrimaryAttribute(cnt).BaseValue);
            //[玩家设置.设置整数(属性名字 ,属性值)]                                                获取的就是BaseValue的值

            PlayerPrefs.SetInt(((AttributeName)cnt).ToString()+" - Exp To Level", pcClass.GetPrimaryAttribute(cnt).ExpToLevel);
            //[玩家设置.设置整数(属性名字 ,属性值)]                                                获取的就是ExpToLevel的值
        }
        //*********保存游戏的基础值***********



        //生命属性
        for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++)        //遍历属性名字
        {
            PlayerPrefs.SetInt(((VitalName)cnt).ToString() + "- Base Value", pcClass.GetVital(cnt).BaseValue);
            //[玩家设置.设置整数(属性名字 ,属性值)]                                                获取的就是BaseValue的值

            PlayerPrefs.SetInt(((VitalName)cnt).ToString() + " - Exp To Level", pcClass.GetVital(cnt).ExpToLevel);
            //[玩家设置.设置整数(属性名字 ,属性值)]                                                获取的就是ExpToLevel的值
            PlayerPrefs.SetInt(((VitalName)cnt).ToString() + " - Cur Value", pcClass.GetVital(cnt).CurValue);
            //[玩家设置.设置整数(属性名字 ,属性值)]                                                获取的就是ExpToLevel的值

            PlayerPrefs.SetString(((VitalName)cnt).ToString() + " - Mods", pcClass.GetVital(cnt).GetModifyingAttributesString()); //获取生命列表
         }


        //技能属性
        for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++)        //遍历属性名字
        {
            PlayerPrefs.SetInt(((SkillName)cnt).ToString() + "- Base Value", pcClass.GetSkill(cnt).BaseValue);
            //[玩家设置.设置整数(属性名字 ,属性值)]                                                获取的就是BaseValue的值

            PlayerPrefs.SetInt(((SkillName)cnt).ToString() + " - Exp To Level", pcClass.GetSkill(cnt).ExpToLevel);
            //[玩家设置.设置整数(属性名字 ,属性值)]                                                获取的就是ExpToLevel的值

            PlayerPrefs.SetString(((SkillName)cnt).ToString() + " - Mods", pcClass.GetSkill(cnt).GetModifyingAttributesString()); //获取技能列表

        }

    }
    public void LoadCharacterData()          //[读取角色数据]
    { 
        
    }


}
