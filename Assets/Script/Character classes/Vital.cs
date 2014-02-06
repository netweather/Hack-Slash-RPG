public class Vital : ModifiedStat   //继承[修改信息]类
{
    private int _curValue;  //当前值(生命的值)
	
	public Vital(){
        _curValue = 0;          //当前生命值
		ExpToLevel = 50;        //升级所需经验
        LevelModifier = 1.1f;   //下次升级所需经验(按百分比)
	}

	public int CurValue {
		get{
			if(_curValue > AdjustedBaseValue) //判断[当前值]不会比我们的MaxHealth[最大生命值]要大
       //[如果](当前值大于调整过的基础值)
			   _curValue = AdjustedBaseValue;
               return _curValue;           //返回当前值
	} 
		set{ 
            _curValue =  value; //[当前值 = 值]
        }

		}
}
	public enum VitalName 
    {
        //生命,
		Health,                 //生命
		Energy,                 //能量
		Mana                    //法力
	}