using UnityEngine;
using System.Collections;
using System;               //快速使用Enum类

public class CharacterGenerator : MonoBehaviour {
    private PlayerCharacter _toon;                      //[私有 玩家角色]
    private const int STARTING_POINTS = 350;            //【起始点数】
    private const int MIN_STARTING_ATTRIBUTE_VALUE = 10;//[最小初始属性值]
    private const int STARTING_VALUE = 50;              //[起始属性]
    private int pointsleft;                             //[剩余点数]

	// Use this for initialization
	void Start () {
        _toon = new PlayerCharacter();                  //[新建 玩家角色]
        _toon.Awake();                                  //{_toon.唤醒]

        pointsleft = STARTING_POINTS;                   //[剩余点数]=【起始点数】

        //设置初始属性值
        for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++)
        {
            _toon.GetPrimaryAttribute(cnt).BaseValue = MIN_STARTING_ATTRIBUTE_VALUE;//将所有的属性的基础值赋值为[最小初始值]
            //_toon.[获取基础属性(索引)].[基础属性]
        }
        _toon.StatUpdate();                         //_toon.更新
    }
	
	// Update is called once per frame
	void Update () {

	
	}

    void OnGUI() {
        DisplayName();          //显示名字
        DisplayPointsleft();    //显示剩余点数
        DisplayAttributes();    //显示属性
        DisplayVitals();        //显示生命属性
        DisplaySkills();        //显示技能属性

    }

    private void DisplayName()              //显示名字
    {
        GUI.Label(new Rect(10, 10, 50, 25), "name:");                       //标签
        _toon.Name = GUI.TextField(new Rect(65, 10, 100, 25), _toon.Name);  //输入框
        //                                   X,  Y,width,height
    }

    private void DisplayAttributes()        //显示属性
    {
        for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++)
        {
            GUI.Label(new Rect(10, 40 + (cnt * 25), 100, 25), ((AttributeName)cnt).ToString());             //显示属性名称
            GUI.Label(new Rect(115, 40 + (cnt * 25), 30, 25), _toon.GetPrimaryAttribute(cnt).AdjustedBaseValue.ToString());//显示属性值
            
            if (GUI.Button(new Rect(150, 40 + (cnt * 25), 25, 25), "-"))            //当按[-]号按钮
            {
                    if (_toon.GetPrimaryAttribute(cnt).BaseValue > MIN_STARTING_ATTRIBUTE_VALUE)        //属性是否大于[最小初始属性值]
                    {
                        _toon.GetPrimaryAttribute(cnt).BaseValue--; //基础属性减1
                        pointsleft++;                               //[剩余点数]+1
                        _toon.StatUpdate();                         //_toon.更新
                    }
              }

            if (GUI.Button(new Rect(180, 40 + (cnt * 25), 25, 25), "+"))            //当按[+]号按钮
            {
                if (pointsleft > 0)                                                  //[剩余点数]>0
                {
                    _toon.GetPrimaryAttribute(cnt).BaseValue++;                     ////属性+1
                    pointsleft--;                                                  //[剩余点数]-1
                    _toon.StatUpdate();                         //_toon.更新
                }
            }
        }

        
    }

    private void DisplayVitals() //显示生命属性
    {
        for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++)
        {
            GUI.Label(new Rect(10, 40 + ((cnt + 7) * 25), 100, 25), ((VitalName)cnt).ToString());
            GUI.Label(new Rect(115, 40 + ((cnt + 7) * 25), 30, 25), _toon.GetVital(cnt).AdjustedBaseValue.ToString());
        }
    }

    private void DisplaySkills()        //显示技能属性
    {
        for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++)
        {
            GUI.Label(new Rect(250, 40 + (cnt * 25), 100, 25), ((SkillName)cnt).ToString());
            GUI.Label(new Rect(355, 40 + (cnt  * 25), 30, 25), _toon.GetSkill(cnt).AdjustedBaseValue.ToString());
        }
    }

    private void DisplayPointsleft()    //显示剩余点数
    {
        GUI.Label(new Rect(250, 10, 100, 25), "Points Left :" + pointsleft.ToString());
        //                                                      规范
       // GUI.Label(new Rect(250, 10, 100, 25), "Points Left :" + pointsleft);

    }




}
