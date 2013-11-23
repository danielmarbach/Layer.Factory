namespace Layer.Factory.Domain
{
    using System.Collections.Generic;

    public interface IFactoryDomainService
    {
        Factory OpenFactory(FactoryId factoryId, string name = "Layer Factory");

        void AssignProducedLayers(FactoryId factoryId, IEnumerable<Layer> producedLayers);
    }
}