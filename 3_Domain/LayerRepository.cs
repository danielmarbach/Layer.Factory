namespace Layer.Factory.Domain
{
    using System.Collections.Generic;
    using System.Transactions;

    using global::Layer.Factory.Data;

    public class LayerRepository : ILayerRepository
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