using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter_Visual : BaseCounter_Visual
{
    [SerializeField] private GameObject sizzlingParticles;
    [SerializeField] private GameObject stoveOnVisual;
    public void CookingPlay(bool isCooking)
    {
        sizzlingParticles.SetActive(isCooking);
        stoveOnVisual.SetActive(isCooking);
    }

}
