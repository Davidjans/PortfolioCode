using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingPlayer : BasePlayerMovement
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
		var input = m_Owner.m_PlayerManager.m_PlayerInput.gameplay.move.ReadValue<Vector2>();
		Move(input);
		base.OnUpdate();
		//CheckStateTransitions(input);
	}
	public override void OnExit()
	{
		base.OnExit();
	}

	/*protected override void CheckStateTransitions(Vector2 input)
	{
		/*if (NoInputCheck(input))
			return;#1#
		if (SprintInputCheck())
			return;
		if (JumpInputCheck())
			return;
	}*/
}
