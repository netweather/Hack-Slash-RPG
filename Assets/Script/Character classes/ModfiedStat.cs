using System.Collections.Generic;
public class ModfiedStat : BaseStat 
{
	private List<ModifyingAttribute>_mods; 		//修改属性列表
	private int _modValue;									//	用来储存从修改器获得的添加到基础值上的值

	public   ModfiedStat()
	{
		_mods = new List<ModifyingAttribute>();
		_modValue = 0;								//修改值
	}
	public  void AddModifier(ModifyingAttribute mod) 
	{
		_mods.Add(mod);		
	}
	
	private void CalculateModValue() {
		_modValue = 0;
		if(_mods.Count >0)
			foreach (ModifyingAttribute att in _mods)
				_modValue += (int)(att.attribute.AdjustedBaseValue * att.ratio);    //把浮点转换为整数
		
	}
	
	public new int AdjustedBaseValue{
		get {return BaseValue + BuffValue + _modValue; }
	}
	public void update () {
		CalculateModValue();
	}
}

public struct ModifyingAttribute {
	public  Attribute attribute ;		//属性
	public float ratio;					//比例
}