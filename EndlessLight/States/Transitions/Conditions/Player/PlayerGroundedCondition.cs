using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerGroundedCondition", menuName = "StackedBeans/TransitionConditions/Player/Grounded", order = 3)]
public class PlayerGroundedCondition : BasePlayerTransitionCondition
{
	public override bool CheckCondition()
	{
		RaycastHit _hit;
		Vector3 boxSize = m_Owner.m_PlayerManager.m_PrimaryCharacterCollider.bounds.extents;
		boxSize.x /=  2;
		boxSize.z /=  2;
		boxSize.y = 0.1f;
		float distance = m_Owner.m_PlayerManager.m_PrimaryCharacterCollider.bounds.extents.y * 1.02f;
		Physics.BoxCast(m_Owner.m_PlayerManager.m_CharacterTransform.position, boxSize, m_Owner.m_PlayerManager.m_CharacterTransform.up *-1, out _hit, Quaternion.identity
			, distance, m_Owner.m_PlayerManager.m_GroundedLayerMask, QueryTriggerInteraction.Ignore);
		if (_hit.collider != null)
		{
			return true;
		}

		return false;
	}
}
