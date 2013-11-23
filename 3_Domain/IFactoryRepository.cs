namespace Layer.Factory.Domain
{
    public interface IFactoryRepository
    {
        void Save(Factory factory);

        Factory Load(FactoryId factoryId);

        void Update(Factory factory);
    }
}