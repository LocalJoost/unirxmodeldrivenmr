namespace ReactNativeDemo.Mvc
{
    public class ObjectDeleteMessage<T> 
    {
        public ObjectDeleteMessage(T model)
        {
            Model = model;
        }
        public T Model {get;}
    }
}
