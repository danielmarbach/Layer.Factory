namespace Layer.Factory.Presentation
{
    using System;
    using System.Collections.Generic;

    using Layer.Factory.Cross;
    using Layer.Factory.Process;

    public class LayerProductionView
    {
        public EventHandler<OpenFactoryEventArgs> OpenFactoryClicked = delegate { };

        public EventHandler<ProduceLayerEventArgs> ProduceLayerClicked = delegate { };

        public void Update(IEnumerable<LayerInfo> layers)
        {
            int count = 0;

            foreach (var layerInfo in layers)
            {
                count++;
                Logger.Log("Updating view for layer " + count);
            }
        }

        public void ClickOpenFactory()
        {
            this.OpenFactoryClicked(this, new OpenFactoryEventArgs("Foo Bar Baz"));
        }

        public void ClickProduceLayer()
        {
            this.ProduceLayerClicked(this, new ProduceLayerEventArgs("Foo Bar Baz", 10));
        }
    }
}