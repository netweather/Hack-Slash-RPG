using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	public  Transform target;			//目标
	public int moveSpeed;				//移动速度
	public int rotationSpeed;			//旋转速度	
	public int	maxDistance;
	
	private Transform myTransform;		//我的形态
	void Awake() {
		myTransform = transform;
		
		
	}

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		//游戏对象 go =获取拥有Play玩家标签的游戏对象
		
		target = go.transform; //获取储存了拥有play玩家标签游戏对象的变量
		maxDistance = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
		Debug.DrawLine(target.position,myTransform.position,Color.red);//绘制一条红线
		//测试.画线【开始点,结束点,颜色】
		//从Player到自己画一条红线
		
		//注视Player
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(target.position - myTransform.position),rotationSpeed * Time.deltaTime);
		//敌人的形态.   【旋转 】 =【四元数】.【平滑插值】(旋转信息，【四元数.注视旋转】（【目标.位置】，【我的目标.位置】），【旋转速度*增量时间】)
		//敌人的旋转 = Quaternion.Slerp(敌人的位置到Player的位置然后旋转多少度);
		//Quaternion.LookRotation(Players的位置 - 敌人的位置)
		//
		//Quaternion 四元数 四元数用来表示旋转     Slerp	球面插值    LookRotation   注视旋转 也就是建立一个旋转，使z轴朝向view  y轴朝向up
		//ookRotation(target.position - myTransform.position)   
		
		if(Vector3.Distance(target.position,myTransform.position)>maxDistance) {
		//向前移动
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
	}
}
