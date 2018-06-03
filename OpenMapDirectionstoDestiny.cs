using UnityEngine;

public class OpenMapDirectionstoDestiny : MonoBehaviour
{
    public static void OpenMapDirectionstoDestiny(string destiny)
    {
        Application.OpenURL("https://www.google.com/maps/dir/?api=1&destination=" + destiny);
    }
}
