using UniRx;
using UnityEngine;

namespace ReactNativeDemo.Mvc
{
    public abstract class ObjectController<T> : MonoBehaviour
    {
        /// <summary>
        /// For display purposes only
        /// </summary>
        [SerializeField] 
        private T _model;

        public ReactiveProperty<T> Model { get; } = new ReactiveProperty<T>();

        protected virtual void Start()
        {
            Model.Subscribe(ProcessModelUpdate).AddTo(this);
        }

        protected virtual void ProcessModelUpdate(T model)
        {
            _model = model;
        }

        public abstract void Delete();
    }
}
