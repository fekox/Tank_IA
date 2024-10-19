using System.Collections.Generic;

public class NeuralComponent : ECSComponent
{
    public List<NeuralNetwork> brains;

    public NeuralComponent(List<NeuralNetwork> newBrainList)
    {
        brains = newBrainList;
    }
}
