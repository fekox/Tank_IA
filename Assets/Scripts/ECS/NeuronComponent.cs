using System.Collections.Generic;

public class NeuronComponent : ECSComponent
{
    List<Neuron> neurons;
    public NeuronComponent(List<Neuron> newNeuronsList)
    {
        neurons = newNeuronsList;
    }
}
