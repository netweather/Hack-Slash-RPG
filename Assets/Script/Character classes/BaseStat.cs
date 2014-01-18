
public class BaseStat{

	private int _baseValue;  		//升级的基础值
	private int _buffValue;			//游戏获得的正面或负面状态
	private int _expToLevel;			//升级所需经验
	private float _levelModifier;  //下次升级所需的经验
	
	public BaseStat () {
		_baseValue = 0;
		_buffValue = 0;
		_levelModifier = 1.1f; //下次升级经验增加10%
		_expToLevel = 100;
	}
	
	
#region  基础设置器和获取器
	//设置和获取器
	public int BaseValue {
		get{ return _baseValue; }
		set{ _baseValue  = value; }
	}
	
		public int BuffValue {
		get{ return _buffValue; }
		set{ _buffValue  = value; }
	}
	
		public int ExpToLevel {
		get{ return _expToLevel; }
		set{ _expToLevel  = value; }
	}
	
		public float LevelModifier {
		get{ return _levelModifier; }
		set{ _levelModifier  = value; }
	}
#endregion

private int CalculateExpToLevel() {						//计算下次升级所需经验
		return (int)( _expToLevel *_levelModifier);			//升级所需经验 * 等级倍增
				//强制转换为INT,小数点后面的都删去.不是四舍五入
	}

	public void LevelUp() {									//升级所需经验
	_expToLevel = CalculateExpToLevel();
	_baseValue++;
	}
	
	public int AdjusedValue() {						//调整基础值和buff
		return _baseValue + _buffValue;
	}
	
}
