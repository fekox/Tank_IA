﻿using UnityEngine;
using System.Collections;

public class TankBase : MonoBehaviour
{
    public float Speed = 10.0f;
    public float RotSpeed = 20.0f;

    protected Genome genome;
	protected NeuralNetwork brain;
    protected GameObject nearMine;
    protected GameObject goodMine;
    protected GameObject badMine;
    protected float[] inputs;

    protected float fitnessMult = 1;
    public float maxFitness = 2;

    protected int badMinesCount = 0;

    private int turnRightCount = 0;
    private int turnLeftCount = 0;

    public void SetBrain(Genome genome, NeuralNetwork brain)
    {
        this.genome = genome;
        this.brain = brain;
        inputs = new float[brain.InputsCount];
        OnReset();
    }

    public void SetNearestMine(GameObject mine)
    {
        nearMine = mine;
    }

    public void SetGoodNearestMine(GameObject mine)
    {
        goodMine = mine;
    }

    public void SetBadNearestMine(GameObject mine)
    {
        badMine = mine;
    }

    protected bool IsGoodMine(GameObject mine)
    {
        return goodMine == mine;
    }

    protected Vector3 GetDirToMine(GameObject mine)
    {
        return (mine.transform.position - this.transform.position).normalized;
    }
    
    protected bool IsCloseToMine(GameObject mine)
    {
        return (this.transform.position - nearMine.transform.position).sqrMagnitude <= 2.0f;
    }

    protected void SetForces(float leftForce, float rightForce, float dt)
    {
        Vector3 pos = this.transform.position;
        float rotFactor = Mathf.Clamp((rightForce - leftForce), -1.0f, 1.0f);
        this.transform.rotation *= Quaternion.AngleAxis(rotFactor * RotSpeed * dt, Vector3.up);
        pos += this.transform.forward * Mathf.Abs(rightForce + leftForce) * 0.5f * Speed * dt;
        this.transform.position = pos;

        if (rightForce > leftForce)
        {
            turnRightCount++;
            turnLeftCount = 0;
        }
        else
        {
            turnLeftCount++;
            turnRightCount = 0;
        }
    }

	public void Think(float dt) 
	{
        const int maxBadMines = 10;
        const float punishment = 0.9f;
        const float reward = 1.5f;
        const int maxTurns = 25;

        OnThink(dt);

        if (IsCloseToMine(nearMine))
        {
            OnTakeMine(nearMine);
            PopulationManager.Instance.RelocateMine(nearMine);
        }

        if (turnRightCount <= maxTurns && turnLeftCount <= maxTurns && badMinesCount < maxBadMines) 
        {
            IncreaseFitnessMod();

            if (fitnessMult > maxFitness)
                fitnessMult = maxFitness;

            genome.fitness += reward * fitnessMult;
        } 

        if (turnRightCount > maxTurns)
        {
            DecreaseFitnessMod();
            genome.fitness *= punishment + 0.03f * fitnessMult;
        }

        else if (turnLeftCount > maxTurns)
        {
            DecreaseFitnessMod();
            genome.fitness *= punishment + 0.03f * fitnessMult;
        }

        if (badMinesCount >= maxBadMines)
        {
            DecreaseFitnessMod();
            genome.fitness *= punishment + 0.03f * fitnessMult;
        }
    }

    protected virtual void OnThink(float dt)
    {

    }

    protected virtual void OnTakeMine(GameObject mine)
    {

    }

    protected virtual void OnReset()
    {

    }

    protected void IncreaseFitnessMod()
    {
        const float MOD = 1.1f;
        fitnessMult *= MOD;
    }

    protected void DecreaseFitnessMod()
    {
        const float MOD = 0.9f;
        fitnessMult *= MOD;
    }
}
