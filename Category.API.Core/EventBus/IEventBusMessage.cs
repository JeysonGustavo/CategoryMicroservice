using Category.API.Core.Models.Request;

namespace Category.API.Core.EventBus
{
    public interface IEventBusMessage
    {
        void PublishNewCategory(CategoryRequestModel requestModel);
    }
}
