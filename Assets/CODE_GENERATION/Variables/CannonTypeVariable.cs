using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class CannonTypeEvent : UnityEvent<CannonType> { }

	[CreateAssetMenu(
	    fileName = "CannonTypeVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "CannonType",
	    order = 120)]
	public class CannonTypeVariable : BaseVariable<CannonType, CannonTypeEvent>
	{
	}
}