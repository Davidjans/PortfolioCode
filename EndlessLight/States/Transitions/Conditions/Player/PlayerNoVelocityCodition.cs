using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerNoVelocityCodition", menuName = "StackedBeans/TransitionConditions/Player/NoVelocity", order = 3)]
public class PlayerNoVelocityCodition : BasePlayerTransitionCondition
{
	public override bool CheckCondition()
	{
		Vector3 velocity = m_Owner.m_PlayerManager.m_CharacterRigidBody.velocity;
		velocity.y = 0;
		if (velocity.sqrMagnitude < 0.01f)
		{
			return true;
		}
		return false;
	}
}
