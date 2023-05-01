using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    [FoldoutGroup("States")]
    [SerializeField] private GameObject m_MovementStatesParent;
    [FoldoutGroup("States")]
    [HideInEditorMode]
    public FSM<PlayerStateManager> m_PlayerMovementState;

    public PlayerCharacterManager m_PlayerManager;
    
    [ShowIf("@Devmode.m_DebugMode")] public string m_CurrentState;


    private void GetInstances()
    {
        m_PlayerMovementState = new FSM<PlayerStateManager>(this, typeof(IdlePlayer), m_MovementStatesParent.GetComponents<BaseState<PlayerStateManager>>());
    }
    // Start is called before the first frame update
    protected async void Start()
    {
        GetInstances();
        await Task.Delay(200);
        if (m_PlayerManager.m_ActiveStateManager != this)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    protected void Update()
    {
        m_PlayerMovementState.OnUpdate();
        m_CurrentState = m_PlayerMovementState.currentState.GetType().ToString();
    }
    protected void PerformWeaponAttack()
    {
        //base.PerformWeaponAttack();
        //m_CurrentWeapon.Attack();
    }
}
