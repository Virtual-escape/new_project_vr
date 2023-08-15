using UnityEngine;
using UnityEngine.XR.Management;

public class DetectVR : MonoBehaviour
{
    public bool startInVR = true;
    public GameObject xrOrigin;
    public GameObject desktopCharacter;
    // Start is called before the first frame update
    void Start()
    {
        if (startInVR)
        {
            var xrSettings = XRGeneralSettings.Instance;
            if (xrSettings == null)
            {
                Debug.Log(message: "XRGeneralSettings is null");
                return;
            }

            var xrManager = xrSettings.Manager;
            if (xrManager == null)
            {
                Debug.Log(message: "XRManagerSettings is null");
                return;
            }

            var xrLoader = xrManager.activeLoader;
            if (xrLoader == null)
            {
                Debug.Log(message: "XRLoader is null");
                xrOrigin.SetActive(false);
                desktopCharacter.SetActive(true);
                return;
            }
            Debug.Log(message: "XRLoader is not null");
            xrOrigin.SetActive(true);
            desktopCharacter.SetActive(false);
            return;

        }
        else
        {
            xrOrigin.SetActive(false);
            desktopCharacter.SetActive(true);
        }
    }
}