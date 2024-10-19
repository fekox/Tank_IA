using System.Collections.Generic;

public class LayerComponent : ECSComponent
{
    List<uint> layers;

    public LayerComponent(List<uint> newLayerList)
    {
        layers = newLayerList;
    }
}
