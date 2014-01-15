using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targetting : MonoBehaviour 
{
	public List<Transform> targets;//列表
	public Transform selectedTarget;//选中的目标
	private Transform myTransform;
	
	void Start () 
	{
		myTransform = transform;
		targets = new List<Transform>();
		selectedTarget = null;
		AddAllEnemies();
	}
	/// <summary>
	/// 添加气人敌人.
	/// </summary>
	public void AddAllEnemies()
	{
		GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
		
		foreach(GameObject enemy in go) //for(元素类型t 元素变量x : 遍历对象obj)
			AddTarget(enemy.transform);
	}
	
	/// <summary>
	/// 添加目标
	/// </summary>
	/// <param name='enemy'>
	/// 敌人.
	/// </param>
	public void AddTarget(Transform enemy)
	{
		targets.Add (enemy);
	}
	
	void Update () 
	{
		//按TAB键选择敌人
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			TargetEnemy();
		}
	}
	/// <summary>
	/// 选中敌人.
	/// </summary>
	private void TargetEnemy()
	{
		if(selectedTarget == null)
		{
			SortTargetByDistance();// 根据距离排列目标.
			selectedTarget = targets[0];//选择最近的
		}
		else
		{
			int index = targets.IndexOf(selectedTarget);
			//索引     =目标.    是索引(选中的目标)
		
			if(index < targets.Count - 1)
		   //如果(索引小于目标.数量    -1)		
		//ps:选中的物体是否小于目标列表所包含的元素个娄 -1 也就是比我们所有元素个数的数量少1
			{
				index++;
			}
			else
			{
				index = 0;
			}
			DeselectTarget();
			selectedTarget = targets[index];
			//选中的目标    =目标[索引]
		}
		SelectTarget();//选中的目标
	}
	/// <summary>
	/// 根据距离排列目标.
	/// </summary>
	private void SortTargetByDistance()
	{
		targets.Sort (delegate(Transform t1,Transform t2)
		//目标.排列 (委托	
		{
			return Vector3.Distance(t1.position,myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position));
			//返回  三维向量.距离 比较(t1.位置    和我们自己的位置)      .比较       (三维向量.距离    (t2.距离     和我我们的距离)
		});
	}
	/// <summary>
	/// 选择目标.
	/// </summary>
	private void SelectTarget()
	{
		selectedTarget.renderer.material.color = Color.yellow;
		//选中的目标.渲染器.材质.颜色
		PlayerAttack pa = (PlayerAttack)GetComponent("PlayerAttack");
		//					(玩家攻击)获取成分
		pa.target = selectedTarget.gameObject;
	}
	/// <summary>
	/// 取消选定目标.
	/// </summary>
	private void DeselectTarget()
	{
		selectedTarget.renderer.material.color = Color.white;
		//选中的目标.渲染器.材质.颜色
		selectedTarget = null;
	}
}
