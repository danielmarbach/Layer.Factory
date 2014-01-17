namespace Layer.Factory.Presentation
{
    using Layer.Factory.Cross;
    using Layer.Factory.Process;

    public class LayerProductionPresenter
    {
        private readonly LayerProductionView view;

        private readonly ILayerProductionApplicationService layerProductionApplicationService;

        public LayerProductionPresenter(LayerProductionView view, ILayerProductionApplicationService layerProductionApplicationService)
        {
            this.layerProductionApplicationService = layerProductionApplicationService;
            this.view = view;
        }

        public void Initialize()
        {
            Logger.Log("Initializing presenter");

            this.view.OpenFactoryClicked += this.HandleOpenFactoryClicked;
            this.view.ProduceLayerClicked += this.HandleProduceLayerClicked;
        }

        private void HandleProduceLayerClicked(object sender, ProduceLayerEventArgs e)
        {
            Logger.Log("Handling Produce Layer Clicked Event");

            var layers = this.layerProductionApplicationService.ProduceLayers(e.FactoryName, e.NumberOfLayers);
            this.view.Update(layers);
        }

        private void HandleOpenFactoryClicked(object sender, OpenFactoryEventArgs e)
        {
            Logger.Log("Handling Open Factory Clicked Event");

            var factoryInfo = this.layerProductionApplicationService.OpenFactory(e.FactoryName);

            Logger.Log(string.Format("Factory {0} opened.", factoryInfo.Name));
        }
    }
}