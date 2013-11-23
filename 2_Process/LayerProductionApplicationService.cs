namespace Layer.Factory.Process
{
    using System.Collections.Generic;
    using System.Linq;

    using Layer.Factory.Domain;

    public class LayerProductionApplicationService : ILayerProductionApplicationService
    {
        private readonly IFactoryDomainService factoryDomainService;

        private readonly ILayerDomainService layerDomainService;

        public LayerProductionApplicationService()
            : this(new FactoryDomainService(new FactoryRepository()), new LayerDomainService(new LayerRepository()))
        {
        }

        public LayerProductionApplicationService(IFactoryDomainService factoryDomainService, ILayerDomainService layerDomainService)
        {
            this.layerDomainService = layerDomainService;
            this.factoryDomainService = factoryDomainService;
        }

        public FactoryInfo OpenFactory(string factoryName)
        {
            var factoryId = new FactoryId(factoryName.Replace(" ", "_"));

            Factory factory = this.factoryDomainService.OpenFactory(factoryId, factoryName);

            return new FactoryInfo(factory.Name)
                   {
                       IsOpened = true,
                   };
        }

        public IEnumerable<LayerInfo> ProduceLayers(string factoryName, int numberOfLayers)
        {
            var factoryId = new FactoryId(factoryName.Replace(" ", "_"));
            
            var producedLayers = this.layerDomainService.ProduceLayers(numberOfLayers);

            this.factoryDomainService.AssignProducedLayers(factoryId, producedLayers);

            return producedLayers.Select(l => new LayerInfo());
        }
    }
}