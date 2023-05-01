using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerMovementInputCondition", menuName = "StackedBeans/TransitionConditions/Player/MovementInput", order = 3)]
public class PlayerMovementInputCondition : BasePlayerTransitionCondition
{
	public override bool CheckCondition()
	{
		if (m_Owner.m_PlayerManager.m_CurrentMovementInput.sqrMagnitude > 0.01f)
		{
			return true;
		}
		return false;
	}
}
