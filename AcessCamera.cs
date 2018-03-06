using UnityEngine;
using UnityEngine.UI;

// Set this script in any GameObject on your scene
public class AcessCamera : MonoBehaviour
{
    [SerializeField] private RawImage showCameraDisplay;
    private bool cameraAvailable;
    private WebCamTexture cameraTexture;
    private AspectRatioFitter aspectRatioFitter;
    public bool getFrontFacing;

    // Use this for initialization
    private void Start()
    {
        var devices = WebCamTexture.devices;
        aspectRatioFitter = showCameraDisplay.GetComponent<AspectRatioFitter>();
        aspectRatioFitter.aspectMode = AspectRatioFitter.AspectMode.EnvelopeParent;

        if (devices.Length == 0)
        {
            print("Not found any device");
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing == getFrontFacing)
            {
                cameraTexture = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                break;
            }
        }

        if (cameraTexture == null)
            return;

        cameraTexture.Play(); // Start the camera
        showCameraDisplay.texture = cameraTexture; // Set the texture on UI
        cameraAvailable = true; // Set the camAvailable for future purposes.
    }

    // Update is called once per frame
    private void Update()
    {
        if (!cameraAvailable)
            return;

        var ratio = (float)cameraTexture.width / cameraTexture.height;
        aspectRatioFitter.aspectRatio = ratio; // Set the aspect ratio
        var scaleY = cameraTexture.videoVerticallyMirrored ? -1f : 1f; // Find if the camera is mirrored or not
        showCameraDisplay.rectTransform.localScale = new Vector3(1f, scaleY, 1f); // Swap the mirrored camera
        var orientation = -cameraTexture.videoRotationAngle;
        showCameraDisplay.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }

    public void PauseCamera()
    {
        if (cameraTexture.isPlaying)
            cameraTexture.Pause();
        else
            cameraTexture.Play();
    }
}
