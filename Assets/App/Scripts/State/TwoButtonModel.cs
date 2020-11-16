using UniRx;

namespace ReactNativeDemo.State
{
    public class TwoButtonModel : ITwoButtonModel
    {
        public BoolReactiveProperty SelectOne { get; } = new BoolReactiveProperty();
        public BoolReactiveProperty SelectTwo { get; } = new BoolReactiveProperty();
    }
}
