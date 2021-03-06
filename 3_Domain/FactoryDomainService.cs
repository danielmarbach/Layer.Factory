﻿namespace Layer.Factory.Domain
{
    using System.Collections.Generic;

    public class FactoryDomainService : IFactoryDomainService
    {
        private readonly IFactoryRepository repository;

        public FactoryDomainService(IFactoryRepository repository)
        {
            this.repository = repository;
        }

        public Factory OpenFactory(FactoryId factoryId, FactoryName name)
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

            this.repository.Update(factory);
        }
    }
}