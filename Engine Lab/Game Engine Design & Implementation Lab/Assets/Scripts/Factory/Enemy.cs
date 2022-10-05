using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // global access for getting the name
    public abstract string Name { get; }

    public abstract GameObject Create(GameObject prefab);
}

public class Crab : Enemy
{
    public override string Name => "crab";

    public override GameObject Create(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab);
        Debug.Log("Crab enemy is Created");
        return enemy;
    }
}

public class Bee : Enemy
{
    public override string Name => "Bee";

    public override GameObject Create(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab);
        Debug.Log("Bee enemy is Created");
        return enemy;
    }
}

