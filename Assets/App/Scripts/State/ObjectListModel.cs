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

        private readonly ReactiveCollection<SimpleDemoModel> shapes = new ReactiveCollection<SimpleDemoModel>();
        
        public IReactiveCollection<SimpleDemoModel> Shapes => shapes;

        private void ProcessDeleteMessage(ObjectDeleteMessage<SimpleDemoModel> objectToDelete)
        {
            if (shapes.Contains(objectToDelete.Model))
            {
                shapes.Remove(objectToDelete.Model);
            }
        }
    }
}
