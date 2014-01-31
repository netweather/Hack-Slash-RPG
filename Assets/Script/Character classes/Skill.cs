public class Skill : ModifiedStat  //继承[修改信息]类
{
	private bool _known;        //[已知]变量 布尔类型
                                //记录角色是否已经学会这个技能
	
	public Skill() {
		_known = false;         //为假
        ExpToLevel = 25;        //升级所需经验
        LevelModifier = 1.1f;    //下次升级所需经验(按百分比)
	}
	
	public bool Known           //获取设置
    {
		get{ return _known; }
		set{_known = value; }
	}
}	
	public enum SkillName       //技能名列表
    {
 		Melee_Offence,		//近战攻击
		Melee_Defence,		//近战防御
		Ranged_Offence,		//远程攻击	
		Ranged_Defence,		//远程防御
		Magic_Offence,		//魔法攻击
		Magic_Defence		//魔法防御
	}