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
        Vector3 dirToMine = GetDirToMine(goodMine);
        Vector3 dirToBadMine = GetDirToMine(badMine);

        inputs[0] = dirToMine.x;
        inputs[1] = dirToMine.z;
        inputs[2] = dirToBadMine.x;
        inputs[3] = dirToBadMine.z;
        inputs[4] = transform.forward.x;
        inputs[5] = transform.forward.z;

        float[] output = brain.Synapsis(inputs);

        SetForces(output[0], output[1], dt);
    }

    protected override void OnTakeMine(GameObject mine)
    {
        const int reward = 15;
        const float punishment = 0.89f;

        if (IsGoodMine(mine))
        {
            IncreaseFitnessMod();
            
            if (fitnessMult > maxFitness) 
                fitnessMult = maxFitness;

            fitness += reward * fitnessMult;
            badMinesCount = 0;
        }

        else
        {
            DecreaseFitnessMod();
            fitness *= punishment * fitnessMult;
            badMinesCount++;
        }
    }
}
