using System.Collections.Generic;

public class LayerComponent : ECSComponent
{
    List<NeuronLayer> layers;

    public LayerComponent(List<NeuronLayer> newLayerList)
    {
        layers = newLayerList;
    }
}
