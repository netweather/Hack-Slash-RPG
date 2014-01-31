using System.Collections.Generic;
public class ModifiedStat : BaseStat
{
    //                       _mods=修改器
    private List<ModifyingAttribute> _mods; 		//一个储存可以修改属性的列表

    private int _modValue;	                    //	用来储存从修改器获得的添加到基础值上的值




    public ModifiedStat()                 // 修改的信息
    {
        _mods = new List<ModifyingAttribute>();
        //[修改器 = 新建 列表<修改属性>]
        _modValue = 0;								//修改值
    }

    public void AddModifier(ModifyingAttribute mod) //添加修改器
    //      [添加修改器([修改属性] [修改器])]
    {
        _mods.Add(mod);
        //[修改器].[添加](mod)
    }

    private void CalculateModValue() //[计算修改值]
    {
        _modValue = 0;
        if (_mods.Count > 0) //[修改器.计数] > [0]
            foreach (ModifyingAttribute att in _mods)   //在_mods【修改器】中寻找所有的ModifyingAttribute【修改属性】
                //【对于每个】循环[修改属性          [值] 在 []修改器]
                _modValue += (int)(att.attribute.AdjustedBaseValue * att.ratio);    //把浮点转换为整数
        //[会改值  +=       att.属     性.修改的值            * att.比例]

    }

    public new int AdjustedBaseValue  //虚函数自BaseStat。
    {
        get
        {
            return BaseValue + BuffValue + _modValue;
        }
    }
    public void update()          //不是MonoBehaviour时候的那个Update是独一无二的类
    {
        CalculateModValue();   //计算修改值
    }

}
//公开 结构 修改属性
public struct ModifyingAttribute        //修改属性
{                                       
	public  Attribute attribute ;		//属性
	public float ratio;					//比例

    public ModifyingAttribute(Attribute att, float rat)
    {
        attribute = att;
        ratio = rat;
    }
}