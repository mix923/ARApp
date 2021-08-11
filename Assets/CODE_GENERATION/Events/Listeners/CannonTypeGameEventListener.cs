using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "CannonType")]
	public sealed class CannonTypeGameEventListener : BaseGameEventListener<CannonType, CannonTypeGameEvent, CannonTypeUnityEvent>
	{
	}
}