namespace Layer.Factory.Domain
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class LayerDomainService
    {
        public IReadOnlyCollection<Layer> ProduceLayers(int numberOfLayers)
        {
            return new ReadOnlyCollection<Layer>(Enumerable.Range(0, numberOfLayers).Select(i => new Layer()).ToList());
        }
    }
}