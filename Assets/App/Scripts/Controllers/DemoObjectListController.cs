using ReactNativeDemo.Mvc;
using ReactNativeDemo.State;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

namespace ReactNativeDemo.Controllers
{
    public class DemoObjectListController : ObjectListController<SimpleDemoModel>
    {
        protected override void Start()
        {
            base.Start();
            while (!MixedRealityToolkit.IsInitialized && Time.time < 1) ;
            SetCollection(MixedRealityToolkit.Instance.GetService<IStateService>().ListModel.Shapes);
        }
    }
}
