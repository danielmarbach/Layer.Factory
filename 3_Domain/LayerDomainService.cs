namespace Layer.Factory.Domain
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class LayerDomainService : ILayerDomainService
    {
        private readonly ILayerRepository repository;

        public LayerDomainService(ILayerRepository repository)
        {
            this.repository = repository;
        }

        public IReadOnlyCollection<Layer> ProduceLayers(LayerQuantity quantity)
        {
            var layers = Enumerable.Range(0, quantity).Select(i => new Layer()).ToList();

            foreach (var layer in layers)
            {
                this.repository.Save(layer);
            }

            return new ReadOnlyCollection<Layer>(layers);
        }
    }
}