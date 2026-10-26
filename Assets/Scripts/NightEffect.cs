using System;
using UnityEngine;

public class NightEffect : MonoBehaviour
{
    [Header("Effet fantôme de nuit")]
    public Material ghostMaterial;

    [Header("Heures")]
    public float dayStart = 6f;     // le jour commence à 6h
    public float nightStart = 18f;  // la nuit commence à 18h

    [Header("Test dans l'éditeur")]
    public bool forceNight = false;

    Renderer[] renderers;
    Material[][] originalMaterials;
    int currentState = -1; // -1 = rien appliqué, 0 = jour, 1 = nuit

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>(true);
        originalMaterials = new Material[renderers.Length][];
        for (int i = 0; i < renderers.Length; i++)
            originalMaterials[i] = renderers[i].sharedMaterials;

        if (ghostMaterial == null)
            Debug.LogWarning("NightEffect : le champ Ghost Material est vide sur " + name);
    }

    void Update()
    {
        if (ghostMaterial == null) return;

        float hour = (float)DateTime.Now.TimeOfDay.TotalHours;
        bool night = forceNight || hour < dayStart || hour >= nightStart;

        int newState = night ? 1 : 0;
        if (newState == currentState) return;
        currentState = newState;

        Apply(night);
    }

    void Apply(bool night)
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            Renderer r = renderers[i];
            if (r == null) continue;

            if (night)
            {
                // Nuit : tous les matériaux de l'animal deviennent le matériau fantôme
                Material[] ghosts = new Material[originalMaterials[i].Length];
                for (int j = 0; j < ghosts.Length; j++) ghosts[j] = ghostMaterial;
                r.sharedMaterials = ghosts;
            }
            else
            {
                // Jour : les matériaux d'origine reviennent
                r.sharedMaterials = originalMaterials[i];
            }
        }
    }
}