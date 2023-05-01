using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerSprintInputCondition", menuName = "StackedBeans/TransitionConditions/Player/SprintInput", order = 3)]
public class PlayerSprintInputCondition : BasePlayerTransitionCondition
{
	public override bool CheckCondition()
	{
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			return true;
		}
		return false;
	}
}
