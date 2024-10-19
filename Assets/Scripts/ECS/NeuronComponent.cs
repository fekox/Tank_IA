using System.Collections.Generic;

//TODO: Neuron y Layer dos componentes separados.
public class NeuronComponent : ECSComponent
{
    List<uint> neurons;

    public NeuronComponent(List<uint> newNeuronsList)
    {
        neurons = newNeuronsList;
    }
}
