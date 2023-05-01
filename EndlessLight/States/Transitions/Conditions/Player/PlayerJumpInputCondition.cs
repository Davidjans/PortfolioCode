using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerJumpInputCondition", menuName = "StackedBeans/TransitionConditions/Player/JumpInput", order = 3)]
public class PlayerJumpInputCondition : BasePlayerTransitionCondition
{
	public override bool CheckCondition()
	{
		if (Input.GetKey(KeyCode.Space) )
		{
			return true;
		}
		return false;
	}
}
