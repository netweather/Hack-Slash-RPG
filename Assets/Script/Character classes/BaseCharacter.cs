using UnityEngine;
using System.Collections;
using System;  //写在这里的话我就可以迅速访问 enum枚举类
public class BaseCharacter : MonoBehaviour {
	private string _name;
	private int _level;
	private uint _freeExp; //可用经验值
	
	private Attribute[] _primaryAttribute;   //属性
	private Vital[] _vital;					//生命属性
	private Skill[] _skill;				//技能
	
	
	public void Awake() {
		_name = string.Empty;
		//名称=字符串.空//
		_level = 0;
		_freeExp = 0;
		
		_primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
		//									[枚举.获取值(类型(属性名称)).长度]//
		_vital = new Vital[Enum.GetValues(typeof(ViatlName)).Length];
		_skill = new Skill[Enum.GetValues(typeof(SkillName)).length];
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
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
	
	public void AddExp(uint exp ){
		_freeExp += exp;
		
		CalculateLevel();
	}
	
	//获取所有技能(等级)然后计算平均值并指定给玩家等级
	public void CalculateLevel(){
		
	}
	
	#region 初始化基础属性,生命属性和技能 
	
	private void SetupPrimaryAttributes() {
		for (int cnt = 0; cnt < _primaryAttribute.Length; cnt++) {
			_primaryAttribute[cnt] = new Attribute();
		}
	}
	
	private void SetupVitals() {
		for (int cnt = 0; cnt < _vitals.Length; cnt++) {
			_vital[cnt] = new Vital();
		}
	}
	
	private void SetupSkills() {
		for (int cnt = 0; cnt < _skill.Length; cnt++) {
			_skill[cnt] = new Skill();
		}
	}
	
	#endregion
	
	
	
}
