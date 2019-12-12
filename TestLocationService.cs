using UnityEngine;
using System.Collections;
using UnityEngine.Android;

public class TestLocationService : MonoBehaviour
{
    private IEnumerator Start()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            print("request access for gps");
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        else
        {
            print("access for gps success");
        }
#endif

        yield return new WaitUntil(() => Permission.HasUserAuthorizedPermission(Permission.FineLocation));

        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            Debug.LogError("Location not enabled on user settings");
            yield break;
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        yield return new WaitWhile(() => Input.location.status == LocationServiceStatus.Initializing);

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.LogError("Unable to determine device location");
            yield break;
        }

        // Access granted and location value could be retrieved
        print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
        print("Disabled get location");
    }
}
