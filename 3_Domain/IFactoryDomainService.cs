namespace Layer.Factory.Domain
{
    using System.Collections.Generic;

    public interface IFactoryDomainService
    {
        Factory OpenFactory(FactoryId factoryId, FactoryName name);

        void AssignProducedLayers(FactoryId factoryId, IEnumerable<Layer> producedLayers);
    }
}