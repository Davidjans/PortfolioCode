using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Sirenix.OdinInspector;

public class BasePlayerMovement : BaseState<PlayerStateManager>
{
	#region InfoBox
	[ShowIf("@Devmode.m_DevmodeDisplayType", DevmodeDisplays.Developer)]
	[SerializeField] protected string m_SimpleInfo = "\nClick for more details";
	[ShowIf("@Devmode.m_DevmodeDisplayType", DevmodeDisplays.Developer)]
	[SerializeField] protected string m_DetailedInfo = "";
	#endregion
	[DetailedInfoBox("$m_SimpleInfo",
		"$m_DetailedInfo", InfoMessageType.Info)]
	[FoldoutGroup("StateSettings")]
	public MovementStyle m_MovementStyle;
	[FoldoutGroup("StateSettings")]
	[HideIf("m_MovementStyle", MovementStyle.Still)]
	public AxisPermitted m_MovementAxis = AxisPermitted.All;
	[FoldoutGroup("StateSettings")]
	[HideIf("m_MovementStyle", MovementStyle.Still)]
	public float m_MovementSpeed = 7;
	public override void Initialize(PlayerStateManager owner)
	{
		base.Initialize(owner);
	}

	public override void OnEnter()
	{
	}
	public override void OnUpdate()
	{
	}
	public override void OnExit()
	{
	}

	public override void TransitionToState(System.Type stateToSwitchTo)
	{
		m_Owner.m_PlayerMovementState.SwitchState(stateToSwitchTo);
	}

	protected void Move(Vector2 input)
	{
		SetHorizontalVelocity(CalculateMovementVelocity(input)); 
	}

	protected virtual Vector3 CalculateMovementDirection(Vector2 input)
	{
		Vector3 _velocity = Vector3.zero;

		_velocity += m_Owner.m_PlayerManager.m_CharacterTransform.right * input.x;
		_velocity += m_Owner.m_PlayerManager.m_CharacterTransform.forward * input.y;

		if (_velocity.magnitude > 1f)
			_velocity.Normalize();

		return _velocity;
	}
	
	protected virtual Vector3 CalculateMovementVelocity(Vector2  input)
	{
		Vector3 _velocity = CalculateMovementDirection(input);

		_velocity *= m_MovementSpeed;

		return _velocity;
	}

	public void SetHorizontalVelocity(Vector3 _velocity)
	{
		_velocity.y = m_Owner.m_PlayerManager.m_CharacterRigidBody.velocity.y;
		m_Owner.m_PlayerManager.m_CharacterRigidBody.velocity = _velocity;
	}

	public void SetVerticalVelocity(float JumpPower)
	{
		m_Owner.m_PlayerManager.m_CharacterRigidBody.AddForce(0,JumpPower,0);
	}

	//void OnDrawGizmos()
	//{
	//	if (boxSize != null)
	//	{
	//		if (_hit.collider)
	//		{
	//			//Draw a Ray forward from GameObject toward the hit
	//			Gizmos.DrawRay(m_Owner.m_CharacterTransform.position, (m_Owner.m_CharacterTransform.up * -1) * _hit.distance);
	//			//Draw a cube that extends to where the hit exists
	//			Gizmos.DrawWireCube(m_Owner.m_CharacterTransform.position + (m_Owner.m_CharacterTransform.up * -1) * _hit.distance, boxSize);
	//		}
	//		else
	//		{
	//			Gizmos.DrawRay(m_Owner.m_CharacterTransform.position, (m_Owner.m_CharacterTransform.up * -1) * (m_Owner.m_PrimaryCharacterCollider.bounds.extents.y * 1.02f));
	//			//Draw a cube that extends to where the hit exists
	//			Gizmos.DrawWireCube(m_Owner.m_CharacterTransform.position + (m_Owner.m_CharacterTransform.up * -1) * (m_Owner.m_PrimaryCharacterCollider.bounds.extents.y * 1.02f), boxSize);
	//		}
	//	}

	//}
}
