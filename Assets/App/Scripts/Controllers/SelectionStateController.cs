using UniRx;
using UnityEngine;
using ReactNativeDemo.Controllers.Base;

namespace ReactNativeDemo.Controllers
{
    public class SelectionStateController : BaseController
    {
        private void OnEnable()
        {
            if(!isInitialized)
            {
                isInitialized = true;
                AppState.ButtonModel.SelectOne.CombineLatest(
                   AppState.ButtonModel.SelectTwo,
                     (one, two) => one && two).Subscribe(
                         r => GetComponent<Renderer>().material.color = r? Color.green: Color.red).
                    AddTo(this);
            }
        }
    }
}
