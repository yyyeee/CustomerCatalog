namespace yyyeee.CustomerCatalog.Services
{
    public interface ICommandHandler<T>
    {
        void Handle(T command);
    }
}