using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlayer : BasePlayerMovement
{
	public override void Initialize(PlayerStateManager owner)
	{
		base.Initialize(owner);
	}

	public override void OnEnter()
	{
		base.OnEnter();
	}
	public override void OnUpdate()
	{
		base.OnUpdate();
		var input = m_Owner.m_PlayerManager.m_PlayerInput.gameplay.move.ReadValue<Vector2>();
		//CheckStateTransitions(input);
	}
	public override void OnExit()
	{
		base.OnExit();
	}

	/*protected override void CheckStateTransitions(Vector2 input)
	{
		//if (AirMoveCheck(input))
		//	return;

		/*if (GroundedCheck())
		{
			if (NoInputCheck(input))
				return;#1#
			//if (WalkInputCheck())
			//	return;
			//if (SprintInputCheck())
			//	return;
		//}
	}*/
}
