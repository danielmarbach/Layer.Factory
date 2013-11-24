namespace Layer.Factory.Domain
{
    using System.Collections.Generic;

    public interface ILayerDomainService
    {
        IReadOnlyCollection<Layer> ProduceLayers(LayerQuantity quantity);
    }
}