using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	
	public GameObject target;//游戏的TAG
	public float attackTimer;//攻击时间
	public float coolDown;	//冷却时间
	
	// Use this for initialization
	void Start () {
		attackTimer = 0;
		coolDown = 2.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(attackTimer >0)
			attackTimer-=Time.deltaTime;
		if(attackTimer <0)
			attackTimer = 0;
		
	  if(Input.GetKeyUp(KeyCode.F)){
			if(attackTimer ==0){
				
			Attack();
				attackTimer = coolDown;
				
			}
		}
	}
		private void Attack(){
			float distance = Vector3.Distance(target.transform.position,transform.position);//定议距离
				//距离    = 【三维向量】.距离【敌人的位置到Player.位置】
			
			Vector3 dir = (target.transform.position - transform.position).normalized;
				//用它的位置和我们的位置创建一个向量.这个向量变为1个单位向量
			float direction = Vector3.Dot (dir,transform.forward);
				//方向    = 【三维向量】.点【dir向量*transform.前方的向量】
				//如果等于1就在前方,如量等于-1则在相反方向,等于0则在侧面
			Debug.Log(direction);
		
		if (distance <2.5f){
			if (direction >0 ){
			EnemyHealth eh=(EnemyHealth)target.GetComponent("EnemyHealth");//引用EnemyHealth脚本
		
		eh.AddjustCurrentHealth(-10)	;//引用EnemyHealth脚本的调整当前生命值
			}
		}
	}
}
