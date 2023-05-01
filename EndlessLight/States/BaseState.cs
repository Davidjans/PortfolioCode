using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
//[CreateAssetMenu(fileName = "BaseState", menuName = "PlayerStates/BasteState", order = 0)]
public abstract class BaseState<T> : MonoBehaviour
{
	protected T m_Owner;
	[FoldoutGroup("Advanced state settings")]
	public bool AllowUpdateOnEnter;
	[FoldoutGroup("Advanced state settings")]
	public bool AllowUpdateOnExit;

	public List<Transition<T>> m_Transitions = new List<Transition<T>>();
	public virtual void Initialize(T owner)
	{
		this.m_Owner = owner;
		foreach (var transition in m_Transitions)
		{
			foreach (var condition in transition.m_Conditions)
			{
				condition.Initialize(owner);
			}
		}
	}

	public abstract void OnEnter();
	public abstract void OnUpdate();
	public abstract void OnExit();

	public virtual void CheckTransitions()
	{
		bool didTransition = false;
		foreach (Transition<T> transition in m_Transitions)
		{
			if (transition.m_MultipleConditionTransition == true)
			{
				didTransition =	CheckMultipleTransition(transition);
			}
			else
			{
				didTransition =	CheckSingleTransition(transition);
			}

			if (didTransition)
				break;
		}
	}

	public virtual bool CheckMultipleTransition(Transition<T> transition)
	{
		int lastSucsessfullCondition = -1;
		foreach (var condition in transition.m_Conditions)
		{
			if (condition.CheckCondition())
			{
				if (!transition.m_SkipFirstConditionForStates || (transition.m_SkipFirstConditionForStates &&
				                                                  transition.m_Conditions.IndexOf(condition) != 0))
					lastSucsessfullCondition++;
			}
			else
			{
				break;
			}
		}

		if (lastSucsessfullCondition > -1)
		{
			TransitionToState(transition.m_StatePerCompletedCondition[lastSucsessfullCondition].GetType());
			return true;
		}
		return false;
	}

	public virtual bool CheckSingleTransition(Transition<T> transition)
	{
		bool shouldTransition = false;
		foreach (var condition in transition.m_Conditions)
		{
			if (condition.CheckCondition())
			{
				shouldTransition = true;
				if(!transition.m_ShouldCompleteAllConditions)
					break;
			}
			else
			{
				shouldTransition = false;
			}
		}
		if (shouldTransition)
		{
			TransitionToState(transition.m_StateToTransitionTo.GetType());
			return true;
		}

		return false;
	}
	
	public abstract void TransitionToState(System.Type stateToSwitchTo);
	
	[Serializable]
	public class Transition<T>
	{
		#region Multiple Conditions
		[Tooltip("When this is true the next condition gets checked if another state to transition to is present.")]
		public bool m_MultipleConditionTransition = false;
		[ShowIf("m_MultipleConditionTransition")]
		public bool m_SkipFirstConditionForStates = true;
		[ShowIf("m_MultipleConditionTransition")]
		public List<BaseState<T>> m_StatePerCompletedCondition;
		#endregion
		#region SingleCondition
		[HideIf("m_MultipleConditionTransition")]
		public BaseState<T> m_StateToTransitionTo;
		[HideIf("m_MultipleConditionTransition")]
		public bool m_ShouldCompleteAllConditions = true;
		#endregion
		
		public List<BaseTransitionCondition<T>> m_Conditions;
	}
}
