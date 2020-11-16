using Microsoft.MixedReality.Toolkit.UI;
using UniRx;
using ReactNativeDemo.Controllers.Base;

namespace ReactNativeDemo.Controllers
{
    public class ToggleButton2Controller : BaseController
    {
        public void SetState()
        {
            AppState.ButtonModel.SelectTwo.Value = GetComponent<Interactable>().IsToggled;
        }

        private void OnEnable()
        {
            if(!isInitialized)
            {
                isInitialized = true;
                AppState.ButtonModel.SelectTwo.Subscribe(
                    p=> GetComponent<Interactable>().IsToggled = p).AddTo(this);
            }
        }
    }
}
