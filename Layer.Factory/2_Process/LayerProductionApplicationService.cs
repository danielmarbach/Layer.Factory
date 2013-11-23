namespace Layer.Factory.Process
{
    using System.Collections.Generic;
    using System.Linq;

    using Layer.Factory.Domain;

    public class LayerProductionApplicationService
    {
        private readonly FactoryDomainService factoryDomainService;

        private readonly LayerDomainService layerDomainService;

        public LayerProductionApplicationService()
            : this(new FactoryDomainService(new FactoryRepository()), new LayerDomainService())
        {
        }

        public LayerProductionApplicationService(FactoryDomainService factoryDomainService, LayerDomainService layerDomainService)
        {
            this.layerDomainService = layerDomainService;
            this.factoryDomainService = factoryDomainService;
        }

        public FactoryInfo OpenFactory(string factoryName)
        {
            var factoryId = new FactoryId(factoryName.Replace(" ", "_"));

            Factory factory = this.factoryDomainService.OpenFactory(factoryId);

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