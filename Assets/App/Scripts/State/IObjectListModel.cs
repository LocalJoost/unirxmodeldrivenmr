using UniRx;

namespace ReactNativeDemo.State
{
    public interface IObjectListModel
    {
        IReactiveCollection<SimpleDemoModel> Shapes {get;}
    }
}
