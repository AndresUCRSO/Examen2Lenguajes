namespace SegundoParcial.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IEventRepository Event { get; }

        void Save();
    }
}
