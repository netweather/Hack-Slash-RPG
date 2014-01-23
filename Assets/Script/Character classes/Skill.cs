public class Skill : ModifiedStat {
	private bool _known;
	
	public Skill() {
		_known = false;
		ExpToLevel = 25;
		LevelModifier =1.1f;
	}
	
	public bool Known {
		get{ return _known; }
		set{_known = value; }
	}
	
	public enum SkillName {
 		Melee_Offence,		//近战攻击
		Melee_Defence,		//近战防御
		Ranged_Offence,		//远程攻击	
		Ranged_Defence,		//远程防御
		Magic_Offence,		//魔法攻击
		Magic_Defence		//魔法防御
		
	}
	
	

}
