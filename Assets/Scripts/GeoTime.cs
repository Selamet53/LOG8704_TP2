using System.Collections;
using UnityEngine;
#if UNITY_ANDROID
using UnityEngine.Android;
#endif

public class GeoTime : MonoBehaviour
{
    public static GeoTime Instance { get; private set; }

    public bool LocationReady { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    public string Status { get; private set; } = "Recherche du GPS...";

    void Awake()
    {
        Instance = this;
    }

    IEnumerator Start()
    {
        yield return null;

#if UNITY_EDITOR
        Latitude = 45.5048;
        Longitude = -73.6132;
        LocationReady = true;
        Status = "GPS simulé (éditeur)";
#elif UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            bool answered = false;
            var callbacks = new PermissionCallbacks();
            callbacks.PermissionGranted += _ => answered = true;
            callbacks.PermissionDenied += _ => answered = true;
            callbacks.PermissionDeniedAndDontAskAgain += _ => answered = true;
            Permission.RequestUserPermission(Permission.FineLocation, callbacks);
            yield return new WaitUntil(() => answered);
        }

        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Status = "Permission GPS refusée";
            yield break;
        }

        if (!Input.location.isEnabledByUser)
        {
            Status = "GPS désactivé sur le téléphone";
            yield break;
        }

        Input.location.Start(5f, 5f);

        int wait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && wait > 0)
        {
            yield return new WaitForSeconds(1f);
            wait--;
        }

        if (wait <= 0 || Input.location.status == LocationServiceStatus.Failed)
        {
            Status = "Position introuvable";
            yield break;
        }

        LocationReady = true;
        Status = "GPS OK";
#endif
    }

    void Update()
    {
#if !UNITY_EDITOR && UNITY_ANDROID
        if (LocationReady && Input.location.status == LocationServiceStatus.Running)
        {
            LocationInfo d = Input.location.lastData;
            Latitude = d.latitude;
            Longitude = d.longitude;
        }
#endif
    }

    void OnDestroy()
    {
#if !UNITY_EDITOR && UNITY_ANDROID
        Input.location.Stop();
#endif
    }
}