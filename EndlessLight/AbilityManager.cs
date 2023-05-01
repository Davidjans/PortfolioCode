using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
	public List<Ability> m_Abilities = new List<Ability>();
	public float m_MaxWax;
	public float m_CurrentWax;
	public float m_WaxReductionIncrement;
	public float m_LooseAbilityPercentage = 20;
	public Ability m_CurrentAbility;
	
	//So the player can reorder abilities as is needed for certain puzzles because abilities get removed when wax ammount is lowered based on location on your body.
	public void ChangeAbilityOrder( int positionsToChangeBy)
	{
		int indexOf = m_Abilities.IndexOf(m_CurrentAbility);
		m_Abilities.Remove(m_CurrentAbility);
		
		if ((indexOf == 0 && positionsToChangeBy == -1) || (indexOf + positionsToChangeBy == m_Abilities.Count))
		{
			m_Abilities.Add(m_CurrentAbility);
		}
		else if (indexOf == m_Abilities.Count  && positionsToChangeBy == 1)
		{
			m_Abilities.Insert(0, m_CurrentAbility);
		}
		else
		{
			m_Abilities.Insert(indexOf + positionsToChangeBy, m_CurrentAbility);
		}

		int newIndexOf = m_Abilities.IndexOf(m_CurrentAbility);
		m_CurrentAbility.transform.SetSiblingIndex(newIndexOf);
	}

	public void ReduceWax(int waxReductionAmmount)
	{
		m_CurrentWax -= waxReductionAmmount;
	}

	public void ChangeCurrentlyOverAbility(Ability abilityOver)
	{
		m_CurrentAbility = abilityOver;
	}

	public void ClearCurrentAbility(Ability abilityExit)
	{
		if (abilityExit == m_CurrentAbility)
		{
			m_CurrentAbility = null;
		}
	}
}