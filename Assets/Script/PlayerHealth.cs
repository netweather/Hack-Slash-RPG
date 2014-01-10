using UnityEngine;
using System.Collections;
/// <summary>
/// Playerhealth.
/// </summary>
public class PlayerHealth : MonoBehaviour {

	public int maxHealth=100;				//最大生命值
	public int curHealth=100;				//当前生命值
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// 在屏幕上绘制血条
	/// </summary>
	void OnGUI(){
	/// <summary>
	/// 按百分比显示血条
	/// </summary>
		GUI.Box (new Rect(10,10,Screen.width/2/(maxHealth/curHealth),20),curHealth+"/"+maxHealth);
			  /// <summary>
			  //【新建 矩形(左边，顶端，场景的宽/2/(最大生命值/当前生命值)，高)当前生命值+"/"+最大生命值】
			  //【新建 矩形(位置)当前生命值+"/"+最大生命值】		
			  //【矩形 位置（左边，顶端，宽，高）】
		      /// </summary>
	}
}
