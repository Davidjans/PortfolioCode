using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem.Interactions;

public class PlayerCharacterManager : BaseCharacter
{
	[HideInEditorMode]
	public PlayerInput m_PlayerInput;
	[HideInEditorMode] public Vector2 m_CurrentMovementInput = new Vector2();
	[HideInEditorMode] public Rigidbody m_CharacterRigidBody;
	[HideInEditorMode] public Transform m_CharacterTransform;
	[HideInEditorMode] public Collider m_PrimaryCharacterCollider;
	
	[ShowIf("@Devmode.m_DebugMode")] public string m_CurrentState;

	public PlayerStateManager m_HumanoidStateManager;
	public PlayerStateManager m_BlobStateManager;
	public PlayerStateManager m_ActiveStateManager;
	
	
	public async void Awake()
	{
		if(!transform.IsChildOf(GlobalVariableHolder.Instance.transform))
			Destroy(gameObject);
		m_PlayerInput = new PlayerInput();
		m_PlayerInput.Enable();
		m_CharacterRigidBody = GetComponent<Rigidbody>();
		m_CharacterTransform = GetComponent<Transform>();
		m_PrimaryCharacterCollider = GetComponent<Collider>();
		AddAttackActions();
		AddUIActions();
		Cursor.visible = false;
		await Task.Delay(2000);
		SwitchActiveState(m_HumanoidStateManager);
	}

	protected void Update()
	{
		m_CurrentMovementInput = m_PlayerInput.gameplay.move.ReadValue<Vector2>();
		if (Input.GetKeyDown(KeyCode.X))
		{
			if (m_ActiveStateManager == m_HumanoidStateManager)
			{
				SwitchActiveState(m_BlobStateManager);
			}
			else if (m_ActiveStateManager == m_BlobStateManager)
			{
				SwitchActiveState(m_HumanoidStateManager);
			}
		}
	}
	
	public void SwitchActiveState(PlayerStateManager managerToSwitchTo)
	{
		if (managerToSwitchTo == m_ActiveStateManager)
			return;
		managerToSwitchTo.enabled = true;
		if (m_ActiveStateManager == null)
		{
			managerToSwitchTo.m_PlayerMovementState.SwitchState(typeof(IdlePlayer));
		}
		else
		{
			m_ActiveStateManager.enabled = false;
			if (managerToSwitchTo.m_PlayerMovementState.stateDictionary.ContainsKey(
				    Type.GetType(m_ActiveStateManager.m_CurrentState)))
				managerToSwitchTo.m_PlayerMovementState.SwitchState(Type.GetType(m_ActiveStateManager.m_CurrentState));
			else
			{
				managerToSwitchTo.m_PlayerMovementState.SwitchState(typeof(IdlePlayer));
			}
		}

		m_ActiveStateManager = managerToSwitchTo;
	}
	
    public override void PerformWeaponAttack()
    {
    }

	protected virtual void AddAttackActions()
    {
	    m_PlayerInput.gameplay.fire.performed +=
		    ctx =>
		    {
			    PerformWeaponAttack();
		    };
    }

	// for future controlelr support
	protected virtual void AddUIActions()
	{
		m_PlayerInput.gameplay.SkillMenu.started +=
			ctx =>
			{
			};
		m_PlayerInput.gameplay.PauseMenu.started +=
			ctx =>
			{
			};
	}
}
