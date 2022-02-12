using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class script1 : Mover
{
	private void FixedUpdate()
	{
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		UpdateMotor (new Vector3 (x, y, 0));
	}
	public void OnLevelUp()
	{
		maxHitpoint++;
		hitpoint = maxHitpoint;

	}
	public void SetLevel(int level)
	{
		for (int i = 0; i < level; i++)
			OnLevelUp ();
	}
}
