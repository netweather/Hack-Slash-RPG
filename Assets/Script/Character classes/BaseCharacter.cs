using UnityEngine;
using System.Collections;
using System;  //写在这里的话我就可以迅速访问 enum枚举类

public class BaseCharacter : MonoBehaviour 
{
	private string _name;   //角色或怪物的名字
	private int _level;     //等级
	private uint _freeExp; //可用经验值或升级所需经验值
    //uint 为正整数.取值范围为10亿到0
    //int 为整数.取值范围为负10亿到10亿
	
	private Attribute[] _primaryAttribute;   //[属性]
	private Vital[] _vital;					//[生命属性]
	private Skill[] _skill;				    //[技能]
	
	
	public void Awake() //[唤醒]功能
    {
		_name = string.Empty; //设置名字为空
		//名称=字符串.空//
		_level = 0;            //等级为0
		_freeExp = 0;          //可用经验值为0
		
		_primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];//最终[基础属性]的样子
		//									[枚举.获取值(类型(属性名称)).长度]//
		_vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
		_skill = new Skill[Enum.GetValues(typeof(SkillName)).Length]; 
		
		SetupPrimaryAttributes();
		SetupVitals();
		SetupSkills();
	}

    #region 基础的设置器和获取器
    public string Name {
		get{ return _name; }
		set{ _name = value; }
	}
	
	public int Level {
		get{ return _level; }
		set{ _level = value; }
	}
	
	public uint FreeExp {
		get{ return _freeExp; }
		set{ _freeExp = value; }
	}
    #endregion

    public void AddExp(uint exp )       //增加经验值
    {
		_freeExp += exp; //可用经验值+=经验值

        CalculateLevel();           //计算等级
	}

    //获取所有技能(等级)然后计算平均值并指定给玩家等级
	public void CalculateLevel()        //计算等级
    {
		
	}
	
	#region 初始化基础属性,生命属性和技能 
	
	private void SetupPrimaryAttributes() //[设置基础属性]
    {
		for (int cnt = 0; cnt < _primaryAttribute.Length; cnt++) {
			_primaryAttribute[cnt] = new Attribute();
		}
	}
	
	private void SetupVitals() //[设置生命属性]
    {
		for (int cnt = 0; cnt < _vital.Length; cnt++) 
			_vital[cnt] = new Vital();

        SetupVitalModifiers();//设置生命属性修改器
    }
	
	private void SetupSkills() //[设置技能]
    {
		for (int cnt = 0; cnt < _skill.Length; cnt++) 
			_skill[cnt] = new Skill();

        SetupSkillModifiers();//设置技能属性修改器
		
	}
	
	#endregion

    #region  设置基础属性,生命和技能的获取器
    public Attribute GetPrimaryAttribute(int index)     //[基础属性]
    {
		return _primaryAttribute[index];                //返回属性
	}
	
	public Vital GetVital(int index)    //[生命属性]
    {
        return _vital[index];            //返回属性
	}
	
	public Skill GetSkill(int index)    //[技能]
    {
        return _skill[index];            //返回属性
	}
#endregion

//#region  设置基础属性,生命和技能
	private void SetupVitalModifiers()          //设置生命属性修改器
    {
		//health  生命
		GetVital((int)VitalName.Health).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Constitution), 0.5f));
    //[获取生命属性]    [属性名称].生命    .            新的 [修改属性]           根据
		//energy	能量
			
		GetVital((int)VitalName.Energy).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Constitution), 1));
		//mana	法力
        GetVital((int)VitalName.Mana).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), 1));
		
		
	}
	
	private void SetupSkillModifiers()          //设置技能属性修改器
    {
        //melee offence
        GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Might), 0.33f));
        GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), 0.33f));
        //melee defence
        GetSkill((int)SkillName.Melee_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), 0.33f));
        GetSkill((int)SkillName.Melee_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), 0.33f));
        //magic offence
        GetSkill((int)SkillName.Magic_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), 0.33f));
        GetSkill((int)SkillName.Magic_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), 0.33f));
        //magic defence
        GetSkill((int)SkillName.Magic_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), 0.33f));
        GetSkill((int)SkillName.Magic_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), 0.33f));
        //ranged offence
        GetSkill((int)SkillName.Ranged_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), 0.33f));
        GetSkill((int)SkillName.Ranged_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), 0.33f));
        //ranged defence
        GetSkill((int)SkillName.Ranged_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), 0.33f));
        GetSkill((int)SkillName.Ranged_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), 0.33f));
	
	}
//#endregion
    public void StatUpdate() {
		for(int cnt = 0; cnt < _vital.Length; cnt++)
			_vital[cnt].update();
		
		for(int cnt = 0; cnt < _skill.Length; cnt++)
			_skill[cnt].update();
	}
}
