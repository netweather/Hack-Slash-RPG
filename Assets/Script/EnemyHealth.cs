using UnityEngine;
using System.Collections;
/// <summary>
/// Playerhealth.
/// </summary>
public class EnemyHealth : MonoBehaviour {

	public int maxHealth=100;				//最大生命值
	public int curHealth=100;				//当前生命值
	
	public float healthBarLength;		    //生命槽长度
	
	// Use this for initialization
	void Start () {
		healthBarLength=Screen.width/2;     //生命槽长度
	}
	
	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth(0);//调整当前生命值
	}
	/// <summary>
	/// 在屏幕上绘制血条
	/// </summary>
	void OnGUI(){
	/// <summary>
	/// 按百分比显示血条
	/// </summary>
		GUI.Box (new Rect(10,40,healthBarLength,20),curHealth+"/"+maxHealth);
			  /// <summary>
			  //【新建 矩形(左边，顶端，生命槽长度，高)当前生命值+"/"+最大生命值】
			  //【新建 矩形(位置)当前生命值+"/"+最大生命值】		
			  //【矩形 位置（左边，顶端，宽，高）】
		      /// </summary>
	}
///调整当前生命值
	public void AddjustCurrentHealth(int adj)
	{
		curHealth+=adj;
		//当前生命值不能小于0不能大于最大生命值
		if(curHealth<0)
			curHealth=0;
		if (curHealth>maxHealth)
			curHealth=maxHealth;
		//最大生命值不能小于1
		if(maxHealth<1)
			maxHealth=1;
			
		healthBarLength=(Screen.width/2)*(curHealth/(float)maxHealth);
		//生命槽长度  =满血的长度值       乘以当前生命值的百分比
	}
}
