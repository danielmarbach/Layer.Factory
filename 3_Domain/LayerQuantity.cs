namespace Layer.Factory.Domain
{
    using System;

    public class LayerQuantity
    {
        private readonly int numberOfLayers;

        public LayerQuantity(int numberOfLayers)
        {
            if (numberOfLayers < 1)
            {
                throw new ArgumentOutOfRangeException("numberOfLayers", numberOfLayers, "Should be greater than one.");
            }

            if (numberOfLayers > 255)
            {
                throw new ArgumentOutOfRangeException("numberOfLayers", numberOfLayers, "Should be smaller than 256.");
            }

            this.numberOfLayers = numberOfLayers;
        }

        public static implicit operator int(LayerQuantity quantity)
        {
            return quantity.numberOfLayers;
        }
    }
}