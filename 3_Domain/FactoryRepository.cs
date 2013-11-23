namespace Layer.Factory.Domain
{
    using System.Transactions;

    using global::Layer.Factory.Data;

    public class FactoryRepository
    {
        public void Save(Factory factory)
        {
            using (var tx = new TransactionScope())
            {
                Database.Insert(factory.Id, factory);

                tx.Complete();
            }
        }

        public Factory Load(FactoryId factoryId)
        {
            return (Factory)Database.Select(factoryId);
        }
    }
}