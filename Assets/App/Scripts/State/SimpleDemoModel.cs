using UniRx;
using System;
using UnityEngine;
using ReactNativeDemo.Mvc;

namespace ReactNativeDemo.State
{
    [Serializable]
    public class SimpleDemoModel
    {
        public SimpleDemoModel()
        {
        }

        public SimpleDemoModel(Vector3 initialPosition)
        {
            this.initialPosition.Value = initialPosition;
        }

        [SerializeField]
        private Vector3ReactiveProperty initialPosition = new Vector3ReactiveProperty();

        public IReadOnlyReactiveProperty<Vector3> InitialPosition => initialPosition;

        public void Delete()
        {
            MessageBroker.Default.Publish(new ObjectDeleteMessage<SimpleDemoModel>(this));
        }
    }
}