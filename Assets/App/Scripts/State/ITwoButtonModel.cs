using UniRx;
using MRTKExtensions.ServiceExtensions;

namespace ReactNativeDemo.State
{
    public interface ITwoButtonModel
    {
        BoolReactiveProperty SelectOne { get; }
        BoolReactiveProperty SelectTwo { get; }
    }
}