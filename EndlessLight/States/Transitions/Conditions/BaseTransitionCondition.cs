using UnityEngine;


public class BaseTransitionCondition<T> : ScriptableObject
{
	public T m_Owner;

	public virtual void Initialize(T owner)
	{
		m_Owner = owner;
		//Debug.LogError(owner);
	}
	
	public virtual void OnEnter(GameObject target)
	{
		
	}
	public virtual void OnExit(GameObject target)
	{

	} 

	public virtual bool CheckCondition()
	{

		return false;
	}
}