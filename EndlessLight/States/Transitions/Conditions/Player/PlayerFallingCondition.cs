using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerFallingCondition", menuName = "StackedBeans/TransitionConditions/Player/Falling", order = 3)]
public class PlayerFallingCondition : BasePlayerTransitionCondition
{
	public override bool CheckCondition()
	{
		if (m_Owner.m_PlayerManager.m_CharacterRigidBody.velocity.y <0)
		{
			return true;
		}
		return false;
	}
}
