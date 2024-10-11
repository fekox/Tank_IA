using UnityEngine;

public class Tank : TankBase
{
    public float fitness = 0;
    protected override void OnReset()
    {
        fitness = 1;
    }

    protected override void OnThink(float dt)
    {
        Vector3 dirToMine = GetDirToMine(nearMine);

        inputs[0] = dirToMine.x;
        inputs[1] = dirToMine.z;
        inputs[2] = transform.forward.x;
        inputs[3] = transform.forward.z;

        float[] output = brain.Synapsis(inputs);

        SetForces(output[0], output[1], dt);
    }

    protected override void OnTakeMine(GameObject mine)
    {
        if (mine.GetComponent<Mine>().isGood)
        {
            fitness *= 2f;
            genome.fitness = fitness;
        }

        else 
        {
            fitness *= 0.3f;
            genome.fitness = fitness;
        }
    }
}
