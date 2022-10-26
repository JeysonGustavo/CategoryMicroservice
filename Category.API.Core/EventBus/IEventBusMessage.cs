using Category.API.Core.Models.Response;

namespace Category.API.Core.EventBus
{
    public interface IEventBusMessage
    {
        void PublishNewCategory(CategoryResponseModel category);
    }
}
