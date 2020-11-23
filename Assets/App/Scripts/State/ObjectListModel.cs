using ReactNativeDemo.Mvc;
using UniRx;

namespace ReactNativeDemo.State
{
    public class ObjectListModel : IObjectListModel
    {
        public ObjectListModel()
        {
            MessageBroker.Default.Receive<ObjectDeleteMessage<SimpleDemoModel>>().Subscribe(ProcessDeleteMessage);
        }

        public IReactiveCollection<SimpleDemoModel> Shapes { get; } = new ReactiveCollection<SimpleDemoModel>();

        private void ProcessDeleteMessage(ObjectDeleteMessage<SimpleDemoModel> objectToDelete)
        {
            if (Shapes.Contains(objectToDelete.Model))
            {
                Shapes.Remove(objectToDelete.Model);
            }
        }
    }
}
