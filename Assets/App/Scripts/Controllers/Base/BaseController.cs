using Microsoft.MixedReality.Toolkit;
using ReactNativeDemo.State;
using UnityEngine;

namespace ReactNativeDemo.Controllers.Base
{
    public abstract class BaseController : MonoBehaviour
    {
        protected bool isInitialized;
        private IStateService state;

        protected IStateService AppState
        {
            get
            {
                while (!MixedRealityToolkit.IsInitialized && Time.time < 1);
                return state ?? (state = MixedRealityToolkit.Instance.GetService<IStateService>());
            }
        }
    }
}
