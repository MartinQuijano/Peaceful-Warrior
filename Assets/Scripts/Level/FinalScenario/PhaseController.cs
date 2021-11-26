using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController : MonoBehaviour
{
    protected int remainingRounds;

    public bool IsPhaseOver()
    {
        return (remainingRounds == 0);
    }
}
