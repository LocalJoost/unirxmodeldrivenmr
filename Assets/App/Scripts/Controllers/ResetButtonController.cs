using ReactNativeDemo.Controllers.Base;

namespace ReactNativeDemo.Controllers
{
    public class ResetButtonController : BaseController
    {
        public void Reset()
        {
            AppState.ButtonModel.SelectOne.Value = false;
            AppState.ButtonModel.SelectTwo.Value = false;
        }
    }
}
