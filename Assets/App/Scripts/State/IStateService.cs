using Microsoft.MixedReality.Toolkit;

namespace ReactNativeDemo.State
{
	public interface IStateService : IMixedRealityExtensionService
	{
        ITwoButtonModel ButtonModel { get; }

        IObjectListModel ListModel { get; }
	}
}