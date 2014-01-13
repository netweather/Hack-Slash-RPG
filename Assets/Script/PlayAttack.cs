using UnityEngine;
using System.Collections;

public class PlayAttack : MonoBehaviour {
	
	public GameObject taregt;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	  if(Input.GetKeyUp(KeyCode.F)){
			Attack();
		}
	}
		private void Attack(){
			float distance = Vector3.Distance(taregt.transform.position,transform.position);//定议距离
				//距离    = 【三维向量】.距离【敌人的位置到Player.位置】
		
			Debug.Log(distance);
		
		if (distance <2){
			EnemyHealth eh=(EnemyHealth)taregt.GetComponent("EnemyHealth");//引用EnemyHealth脚本
		
		eh.AddjustCurrentHealth(-10)	;//引用EnemyHealth脚本的调整当前生命值
		}
	}
}
