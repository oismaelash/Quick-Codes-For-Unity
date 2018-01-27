using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class VuMarkEvent : MonoBehaviour
{
	[SerializeField] private List<GameObject> m_ModelList;
	[SerializeField] private List<string> m_IdList;

	private int modelN;
	private VuMarkManager vuMarkManager;

	private void Start ()
    {
		vuMarkManager = TrackerManager.Instance.GetStateManager().GetVuMarkManager(); // Set VuMarkManager
        vuMarkManager.RegisterVuMarkDetectedCallback(OnVuMarkDetected); // Set VuMark detected
        vuMarkManager.RegisterVuMarkLostCallback(OnVuMarkLost); // Set VuMark Lost

        //foreach (var model in m_ModelList) // Deactivate all models 
        //    model.SetActive (false);
    }
    
	private string GetStringVuMarkID(VuMarkTarget vuMark)
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

    private int GetIntVuMarkID(VuMarkTarget vuMark)
    {
        switch (vuMark.InstanceId.DataType)
        {
            case InstanceIdType.BYTES:
                return Convert.ToInt32(vuMark.InstanceId.HexStringValue);
            case InstanceIdType.STRING:
                return Convert.ToInt32(vuMark.InstanceId.StringValue);
            case InstanceIdType.NUMERIC:
                return Convert.ToInt32(vuMark.InstanceId.NumericValue);
        }

        return 404;
    }

    public void OnVuMarkDetected(VuMarkTarget target)
    {
        Debug.Log("Detected ID: " + target.InstanceId);

        for (int i = 0; i < m_IdList.Count; i++) // Find and activate model by VuMark ID
        {
            //if (int.Parse(m_IdList[i]) == GetIntVuMarkID(target)) // When ID is type Int
            if (m_IdList[i] == GetStringVuMarkID(target)) // When ID is type String
            {
                //m_ModelList[i].SetActive(true);
                m_ModelList[i].GetComponent<StartVideoDynamicVuMark>().rendererVideo.SetActive(true);
                m_ModelList[i].GetComponent<VideoPlayer>().Play();
                m_ModelList[i].GetComponent<AudioSource>().Play();
                modelN = i; // Set model number
            }
        }
	}

	public void OnVuMarkLost(VuMarkTarget target)
    {
		Debug.Log ("Lost ID: "+ target.InstanceId);
        //m_ModelList [modelN].SetActive (false); // Deactivate model by model number
        m_ModelList[modelN].GetComponent<StartVideoDynamicVuMark>().rendererVideo.SetActive(false);
        m_ModelList[modelN].GetComponent<VideoPlayer>().Pause();
        m_ModelList[modelN].GetComponent<AudioSource>().Pause();
    }
}
