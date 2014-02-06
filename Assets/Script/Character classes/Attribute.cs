public class Attribute : BaseStat {
    private string _name;

	public Attribute()              //属性类
    {
        _name = "";                 //名字为空
		ExpToLevel = 50;			//升级所需经验
		LevelModifier = 1.05f;		//下次经验%5
		}

    public string Name {
        get { return _name; }
        set {_name = value;}

    }
}


/// <summary>
/// 所有属性列表
/// </summary>
public enum AttributeName 
{
	Might,					//魔法
    Constitution,			//体质
	Nimbleness,			    //敏捷
	Speed,					//速度
	Concentration,		    //集中
	Willpower,				//意志力
	Charisma  			    //魅力
}