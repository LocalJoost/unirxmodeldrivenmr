using Microsoft.MixedReality.Toolkit.Utilities;
using ReactNativeDemo.Controllers.Base;
using ReactNativeDemo.State;
using UnityEngine;

namespace ReactNativeDemo.Controllers
{
    public class ListMenuController : BaseController
    {
        public void Add()
        {
            AppState.ListModel.Shapes.Add(
                new SimpleDemoModel(
                    new Vector3(Random.value, Random.value, Random.value) * 0.5f + CameraCache.Main.transform.forward));
        }

        public void Clear()
        {
            AppState.ListModel.Shapes.Clear();
        }
    }
}
