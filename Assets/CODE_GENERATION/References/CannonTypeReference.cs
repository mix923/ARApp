using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class CannonTypeReference : BaseReference<CannonType, CannonTypeVariable>
	{
	    public CannonTypeReference() : base() { }
	    public CannonTypeReference(CannonType value) : base(value) { }
	}
}