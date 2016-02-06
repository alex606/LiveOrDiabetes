/*using UnityEngine;
using System.Collections;

public class attackTrigger : MonoBehavior 
{
	
	public int dmg = 20;
	
	void OnTriggerEnter20(Collider2D col)
	{
		if (col.isTrigger is true && col.CompareTag("Enemy"))
		{
			col.SendMessageUpwards("Damage", dmg)
		}
	}
}*/