using System;
using TMPro;
using UnityEngine;

public class HudDisplay : MonoBehaviour
{
    public TMP_Text text;

    void Update()
    {
        GeoTime p = GeoTime.Instance;
        if (p == null || text == null) return;

        string heure = DateTime.Now.ToString("HH:mm:ss");

        string gps = p.LocationReady
            ? "Lat : " + p.Latitude.ToString("F5") + "\nLon : " + p.Longitude.ToString("F5")
            : p.Status;

        text.text = "Heure : " + heure + "\n" + gps;
    }
}