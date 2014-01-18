public class Attribute : BaseStat {
	public Attribute() {
		ExpToLevel = 50;				//升级所需经验
		LevelModifier = 1.05f;		//下次经验%5
	
	}
}


/// <summary>
/// 所有属性列表
/// </summary>
public enum AttributeName {
	Might,					//魔法
	Constituion,			//体质
	Nimbleness,			//敏捷
	Speed,					//速度
	Concentration,		//集中
	WillPower,				//意志力
	Charisma  			//魅力
}