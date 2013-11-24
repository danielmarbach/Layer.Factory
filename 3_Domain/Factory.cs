namespace Layer.Factory.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using global::Layer.Factory.Cross;

    public class Factory
    {
        private readonly FactoryId factoryId;

        private readonly List<Layer> producedLayers;

        public Factory(FactoryId factoryId, FactoryName name)
        {
            this.factoryId = factoryId;
            this.Name = name;

            this.producedLayers = new List<Layer>();
        }

        public DateTimeOffset OpenedAt { get; private set; }

        public FactoryName Name { get; private set; }

        public ReadOnlyCollection<Layer> ProducedLayers
        {
            get
            {
                return new ReadOnlyCollection<Layer>(this.producedLayers);
            }
        } 

        public FactoryId Id
        {
            get
            {
                return this.factoryId;
            }
        }

        public void Open()
        {
            this.OpenedAt = SystemClock.Now();
        }

        public void Assign(IEnumerable<Layer> layers)
        {
            this.producedLayers.AddRange(layers);
        }
    }
}