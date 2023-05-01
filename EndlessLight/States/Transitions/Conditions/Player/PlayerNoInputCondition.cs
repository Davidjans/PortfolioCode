using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerNoInputCondition", menuName = "StackedBeans/TransitionConditions/Player/NoInput", order = 3)]
public class PlayerNoInputCondition : BasePlayerTransitionCondition
{
	public override bool CheckCondition()
	{
		if (m_Owner.m_PlayerManager.m_CurrentMovementInput.sqrMagnitude < 0.01f)
		{
			return true;
		}
		return false;
	}
}
