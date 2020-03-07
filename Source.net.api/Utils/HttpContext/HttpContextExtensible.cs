using Source.net.infrastructure.Views;

namespace Source.net.api.Utils.HttpContext
{
    public interface HttpContextExtensible
    {
        UserView getUser();
    }
}
