using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "CannonTypeGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "CannonType",
	    order = 120)]
	public sealed class CannonTypeGameEvent : GameEventBase<CannonType>
	{
	}
}