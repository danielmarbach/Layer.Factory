namespace Layer.Factory.Domain
{
    using System.Transactions;

    using global::Layer.Factory.Data;

    public class LayerRepository
    {
        public void Save(Layer layer)
        {
            using (var tx = new TransactionScope())
            {
                Database.Insert(layer.Id, layer);

                tx.Complete();
            }
        }
    }
}