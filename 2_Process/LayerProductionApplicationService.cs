namespace Layer.Factory.Process
{
    using System.Collections.Generic;
    using System.Linq;

    using Layer.Factory.Domain;

    public class LayerProductionApplicationService : ILayerProductionApplicationService
    {
        private readonly IFactoryDomainService factoryDomainService;

        private readonly ILayerDomainService layerDomainService;

        public LayerProductionApplicationService(IFactoryDomainService factoryDomainService, ILayerDomainService layerDomainService)
        {
            this.layerDomainService = layerDomainService;
            this.factoryDomainService = factoryDomainService;
        }

        public FactoryInfo OpenFactory(string factoryName)
        {
            var factoryId = new FactoryId(factoryName.Replace(" ", "_"));
            var name = new FactoryName(factoryName);

            Factory factory = this.factoryDomainService.OpenFactory(factoryId, name);

            return new FactoryInfo(factory.Name)
                   {
                       IsOpened = true,
                   };
        }

        public IEnumerable<LayerInfo> ProduceLayers(string factoryName, int numberOfLayers)
        {
            var factoryId = new FactoryId(factoryName.Replace(" ", "_"));
            var quanity = new LayerQuantity(numberOfLayers);

            var producedLayers = this.layerDomainService.ProduceLayers(quanity);

            this.factoryDomainService.AssignProducedLayers(factoryId, producedLayers);

            return producedLayers.Select(l => new LayerInfo());
        }
    }
}