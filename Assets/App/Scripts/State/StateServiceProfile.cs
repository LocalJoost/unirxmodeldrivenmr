using UnityEngine;
using Microsoft.MixedReality.Toolkit;

namespace ReactNativeDemo.State
{
	[MixedRealityServiceProfile(typeof(IStateService))]
	[CreateAssetMenu(fileName = "StateServiceProfile", menuName = "MixedRealityToolkit/StateService Configuration Profile")]
	public class StateServiceProfile : BaseMixedRealityProfile
	{
		
		// Store config data in serialized fields
	}
}