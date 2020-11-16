using Microsoft.MixedReality.Toolkit.UI;
using UniRx;
using ReactNativeDemo.Controllers.Base;

namespace ReactNativeDemo.Controllers
{
    public class ToggleButton1Controller : BaseController
    {
        public void SetState()
        {
            AppState.ButtonModel.SelectOne.Value = GetComponent<Interactable>().IsToggled;
        }

        private void OnEnable()
        {
            if(!isInitialized)
            {
                isInitialized = true;
                AppState.ButtonModel.SelectOne.Subscribe(
                    p=> GetComponent<Interactable>().IsToggled = p).AddTo(this);
            }
        }
    }
}
