using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VuMarkEvent : MonoBehaviour
{
	public List<GameObject> m_ModelList;
	public List<string> m_IdList;

	private int modelN;
	private VuMarkManager vuMarkManager;

	private void Start ()
    {
		vuMarkManager = TrackerManager.Instance.GetStateManager().GetVuMarkManager(); // Set VuMarkManager
        vuMarkManager.RegisterVuMarkDetectedCallback(OnVuMarkDetected); // Set VuMark detected
        vuMarkManager.RegisterVuMarkLostCallback(OnVuMarkLost); // Set VuMark Lost

        foreach (var model in m_ModelList) // Deactivate all models 
            model.SetActive (false);
    }
    
	private string GetVuMarkID(VuMarkTarget vuMark)
    {
		switch (vuMark.InstanceId.DataType)
        {
		    case InstanceIdType.BYTES:
			    return vuMark.InstanceId.HexStringValue;
		    case InstanceIdType.STRING:
			    return vuMark.InstanceId.StringValue;
		    case InstanceIdType.NUMERIC:
			    return vuMark.InstanceId.NumericValue.ToString();
            default:
                return null;
        }
	}

	public void OnVuMarkDetected(VuMarkTarget target)
    {
		Debug.Log ("Detected ID: "+ GetVuMarkID(target));
        for (int i = 0; i < m_IdList.Count; i++) // Find and activate model by VuMark ID
        {
            if (int.Parse(m_IdList[i]) == int.Parse(GetVuMarkID (target)))
            {
				m_ModelList [i].SetActive (true);
				modelN = i; // Set model number
            }
		}
	}

	public void OnVuMarkLost(VuMarkTarget target)
    {
		Debug.Log ("Lost ID: "+ GetVuMarkID(target));
		m_ModelList [modelN].SetActive (false); // Deactivate model by model number
    }
}
