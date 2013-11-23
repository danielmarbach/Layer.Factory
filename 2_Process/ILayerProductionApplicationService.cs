namespace Layer.Factory.Process
{
    using System.Collections.Generic;

    public interface ILayerProductionApplicationService
    {
        FactoryInfo OpenFactory(string factoryName);

        IEnumerable<LayerInfo> ProduceLayers(string factoryName, int numberOfLayers);
    }
}