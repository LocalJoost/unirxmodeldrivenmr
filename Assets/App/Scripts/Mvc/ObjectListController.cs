using UniRx;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace ReactNativeDemo.Mvc
{
    public class ObjectListController<T> : MonoBehaviour
    {
        private CompositeDisposable subscriptions;

        [SerializeField]
        private GameObject viewObject;

        [SerializeField]
        private GameObject parentObject;

        /// <summary>
        /// The list of models and the gameobjects created for each of them
        /// </summary>
        private Dictionary<T, GameObject> views = new Dictionary<T, GameObject>();

        protected virtual void Start()
        {
            // If not parent object defined, use gameobject where this behaviour is attached to
            if (parentObject == null)
            {
                parentObject = gameObject;
            }
        }

        /// <summary>
        /// Sets the collection to be processed by this behaviour
        /// </summary>
        /// <param name="collection"></param>
        public void SetCollection(IReactiveCollection<T> collection)
        {
            // Delete previous collection and views
            ClearSubscriptions();
            DestroyAllViews();

            subscriptions = new CompositeDisposable();
            collection.ObserveAdd().Subscribe(evt => ProcessAdd(evt.Value)).AddTo(subscriptions);
            collection.ObserveRemove().Subscribe(evt => ProcessRemove(evt.Value)).AddTo(subscriptions);
            collection.ObserveReset().Subscribe(ProcessReset).AddTo(subscriptions);

            // Add all initial objects
            foreach (var model in collection)
            {
                ProcessAdd(model);
            }
        }

        /// <summary>
        /// Process adding of a model - create and push the model in it
        /// </summary>
        /// <param name="model"></param>
        private void ProcessAdd(T model)
        {
            var view = Instantiate(viewObject, parentObject.transform);
            var modelHolder = view.GetComponent<ObjectController<T>>();
            modelHolder.Model.Value = model;
            views.Add(model, view);
        }

        /// <summary>
        /// Process removal of a single model
        /// </summary>
        /// <param name="model"></param>
        private void ProcessRemove(T model)
        {
            if (views.Keys.Contains(model))
            {
                Destroy(views[model]);
                views.Remove(model);
            }
        }

        /// <summary>
        /// Collection cleared
        /// </summary>
        /// <param name="obj"></param>
        private void ProcessReset(Unit obj)
        {
            DestroyAllViews();
        }

        /// <summary>
        /// Remove all created gameobjects
        /// </summary>
        private void DestroyAllViews()
        {
            foreach (var view in views.Values)
            {
                Destroy(view);
            }
            views.Clear();
        }

        protected virtual void OnDestroy()
        {
            ClearSubscriptions();
        }

        /// <summary>
        /// Remove all subscriptions
        /// </summary>
        private void ClearSubscriptions()
        {
            subscriptions?.Dispose();
        }
    }
}
