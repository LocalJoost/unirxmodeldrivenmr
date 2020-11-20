using ReactNativeDemo.Mvc;
using ReactNativeDemo.State;
using UnityEngine;
using UniRx;
using Microsoft.MixedReality.Toolkit.Input;
using System;

namespace ReactNativeDemo.Controllers
{
    public class SimpleObjectController : ObjectController<SimpleDemoModel>, IMixedRealityTouchHandler 
    {
        protected override void ProcessModelUpdate(SimpleDemoModel model)
        {
            base.ProcessModelUpdate(model);
            if (Model.Value != null)
            {
                model.InitialPosition.Subscribe(
                    ip => gameObject.transform.position = ip).AddTo(this);
            }
        }

        public override void Delete()
        {
            Model?.Value?.Delete();
        }

        public void OnTouchStarted(HandTrackingInputEventData eventData)
        {
            GetComponent<AudioSource>()?.Play();
            Scheduler.MainThread.Schedule(TimeSpan.FromMilliseconds(200), Delete);
        }

        public void OnTouchCompleted(HandTrackingInputEventData eventData)
        {
        }

        public void OnTouchUpdated(HandTrackingInputEventData eventData)
        {
        }
    }
}
