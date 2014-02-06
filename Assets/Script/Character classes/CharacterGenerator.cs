using UnityEngine;
using System.Collections;
using System;               //快速使用Enum类

public class CharacterGenerator : MonoBehaviour 
{
    private PlayerCharacter _toon;                      //【私有 玩家角色】
    private const int STARTING_POINTS = 350;            //【起始点数】
    private const int MIN_STARTING_ATTRIBUTE_VALUE = 10;//【最小初始属性值】
    private const int STARTING_VALUE = 50;              //【起始属性】
    private int pointsleft;                             //【剩余点数】


    private const int OFFSET =5;        //偏移
    private const int LINE_HEIGHT = 20;  // 行高

    private const int STAT_LABEL  = 100; //信息标签
    private const int STAT_LABEL_WIDTH = 100;   ////信息标签宽
    private const int BASEVALUE_LABEL_WIDTH = 30;   ///基础值标签宽度
                                                    ///
    private const int BUTTON_WIDTH = 20;    //按钮宽度
    private const int BUTTON_HEIGHT = 20;    //按钮高度

    private int statStartingPos = 40;        //信息起始位置

    //public GUIStyle myStyle;                //GUI风格
    public GUISkin mySkin;                  //GUI皮肤

    public GameObject PlayerPrefab;         //角色Prefab




	// Use this for initialization
	void Start () {
        GameObject pc = Instantiate(PlayerPrefab,Vector3.zero,Quaternion.identity) as GameObject;
        //游戏对象 pc = [实例(角色Prefab,[三维向量.零点],[四元数.同一性]               设置为   游戏对象]

        pc.name = "pc";
        //pc.名字
       // _toon = new PlayerCharacter();                  //【新建 玩家角色】
       // _toon.Awake();                                  //【_toon.唤醒】

          _toon=pc.GetComponent<PlayerCharacter>();
        //_toon=pc.获取的成分<>

        pointsleft = STARTING_POINTS;                   //【剩余点数】=【起始点数】

        //设置初始属性值
        for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++)
        {
            _toon.GetPrimaryAttribute(cnt).BaseValue = STARTING_VALUE;//将所有的属性的基础值赋值为【起始属性】
            //_toon.【获取基础属性(索引)】.【基础属性】

            pointsleft -= (STARTING_VALUE - MIN_STARTING_ATTRIBUTE_VALUE);
            //【剩余点数】 -= 【起始属性】 - 【最小初始属性值】
        }
        _toon.StatUpdate();                         //_toon.更新
    }
	
	// Update is called once per frame
	void Update () {

	
	}

    void OnGUI() 
    {
        GUI.skin = mySkin;     //皮肤

        DisplayName();          //显示名字
        DisplayPointsleft();    //显示剩余点数
        DisplayAttributes();    //显示属性
        DisplayVitals();        //显示生命属性
        DisplaySkills();        //显示技能属性

        DisplayCreateButton();  //显示创建按钮

    }

    private void DisplayName()              //显示名字
    {
        GUI.Label(new Rect(10, 10, 50, 25), "Name:");                       //标签
        _toon.Name = GUI.TextField(new Rect(65, 10, 100, 25), _toon.Name);  //输入框
        //                                   X,  Y,width,height
    }

    private void DisplayAttributes()        //显示属性
    {
        for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++)
        {
            GUI.Label(new Rect(//显示属性名称
                OFFSET,                                     //x
                statStartingPos + (cnt * LINE_HEIGHT),      //y
                STAT_LABEL_WIDTH,                           //width
                LINE_HEIGHT                                 //height
                ), ((AttributeName)cnt).ToString());

            GUI.Label(new Rect(                             //显示属性值
                STAT_LABEL_WIDTH + OFFSET,                  //x
                statStartingPos + (cnt * LINE_HEIGHT),      //y
                BASEVALUE_LABEL_WIDTH,                      //width
                LINE_HEIGHT                                 //height
                ), _toon.GetPrimaryAttribute(cnt).AdjustedBaseValue.ToString());

            if (GUI.Button(new Rect(                                 //当按【-】号按钮
                OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH,   //x
                statStartingPos + (cnt * BUTTON_HEIGHT),             //y
                BUTTON_WIDTH,                                        //width
                BUTTON_HEIGHT                                        //height
                ), "-"))           

            {
                if (_toon.GetPrimaryAttribute(cnt).BaseValue > MIN_STARTING_ATTRIBUTE_VALUE)        //属性是否大于【最小初始属性值】
                {
                    _toon.GetPrimaryAttribute(cnt).BaseValue--; //基础属性减1
                    pointsleft++;                               //【剩余点数】+1
                    _toon.StatUpdate();                         //_toon.更新
                }
            }

            if (GUI.Button(new Rect(                                                //当按【+】号按钮
                OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH,   //x
                statStartingPos + (cnt * BUTTON_HEIGHT),                            //y
                BUTTON_WIDTH,                                                       //width
                BUTTON_HEIGHT                                                       //height
                ), "+"))    

            {
                if (pointsleft > 0)                                                  //【剩余点数】>0
                {
                    _toon.GetPrimaryAttribute(cnt).BaseValue++;                     ////属性+1
                    pointsleft--;                                                  //【剩余点数】-1
                    _toon.StatUpdate();                         //_toon.更新
                }
            }
        }
    }
        
    private void DisplayVitals() //显示生命属性
    {
        for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++)
        {
            GUI.Label(new Rect(
                OFFSET,                                             //x
                statStartingPos + ((cnt + 7) * LINE_HEIGHT),        //y
                STAT_LABEL_WIDTH,                                   //width
                LINE_HEIGHT                                         //height
                ), ((VitalName)cnt).ToString());

            GUI.Label(new Rect(
                OFFSET + STAT_LABEL_WIDTH,                          //x
                statStartingPos + ((cnt + 7) * LINE_HEIGHT),        //y
                BASEVALUE_LABEL_WIDTH,                              //width
                LINE_HEIGHT                                         //height
                ), _toon.GetVital(cnt).AdjustedBaseValue.ToString());

        }
    }
    
    private void DisplaySkills()        //显示技能属性
    {
        for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++)
        {
            GUI.Label(new Rect(
                OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH * 2 + OFFSET * 2,  //x
                statStartingPos + (cnt * LINE_HEIGHT),                                              //y
                STAT_LABEL_WIDTH + OFFSET*2,                                                                   //width
                LINE_HEIGHT                                                                         //height
                ), ((SkillName)cnt).ToString());

            GUI.Label(new Rect(
                OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH * 2 + OFFSET * 5 + STAT_LABEL_WIDTH, //x
                statStartingPos + (cnt * LINE_HEIGHT),                                                                //y
                BASEVALUE_LABEL_WIDTH,                                                                                //width
                LINE_HEIGHT                                                                                           //height
                ), _toon.GetSkill(cnt).AdjustedBaseValue.ToString());

        }
    }
    
    
    private void DisplayPointsleft()    //显示剩余点数
    {
        GUI.Label(new Rect(250, 10, 100, 25), "Points Left :" + pointsleft.ToString());
        //                                                      规范
       // GUI.Label(new Rect(250, 10, 100, 25), "Points Left :" + pointsleft);

    }

    private void DisplayCreateButton()      //显示创建按钮
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, statStartingPos + (10 * LINE_HEIGHT), 100, LINE_HEIGHT), "Create"))
        {
            //           简单的写法
            GameSettings gsScript = GameObject.Find ("__GameSettings").GetComponent<GameSettings>();
            //                      查找__GameSettings游戏对象       . 获取成分<GameSettings>

            //改变生命属性(Vital)的当前值(Cur Value)为它的最大修改值

            gsScript.SaveCharacterData();            
            //保存数据
        
            Application.LoadLevel("Targetting Example");
            //载入场景
        }
    }



}