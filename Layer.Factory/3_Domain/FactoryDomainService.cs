namespace Layer.Factory.Domain
{
    using System.Collections.Generic;

    public class FactoryDomainService
    {
        private readonly FactoryRepository repository;

        public FactoryDomainService(FactoryRepository repository)
        {
            this.repository = repository;
        }

        public Factory OpenFactory(FactoryId factoryId, string name = "Layer Factory")
        {
            var factory = new Factory(factoryId, name);

            factory.Open();

            this.repository.Save(factory);

            return factory;
        }

        public void AssignProducedLayers(FactoryId factoryId, IEnumerable<Layer> producedLayers)
        {
            var factory = this.repository.Load(factoryId);

            factory.Assign(producedLayers);
        }
    }
}