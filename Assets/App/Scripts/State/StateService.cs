using System;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit;

namespace ReactNativeDemo.State
{
	[Serializable]
	[MixedRealityExtensionService(SupportedPlatforms.WindowsStandalone|SupportedPlatforms.MacStandalone|SupportedPlatforms.LinuxStandalone|SupportedPlatforms.WindowsUniversal)]
	public class StateService : BaseExtensionService, IStateService, IMixedRealityExtensionService
	{
		private StateServiceProfile stateServiceProfile;

		public StateService(string name,  uint priority,  BaseMixedRealityProfile profile) :
            base(name, priority, profile) 
		{
			stateServiceProfile = (StateServiceProfile)profile;
		}

		public ITwoButtonModel ButtonModel { get; } = new TwoButtonModel();
    }
}
