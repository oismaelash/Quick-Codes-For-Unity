using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackgrounds : MonoBehaviour
{
    public static ScrollingBackgrounds Instance;
    [SerializeField]
    private List<GameObject> m_Backgrounds;
    [HideInInspector]
    public int number;
    private int index = 0;

    // Use this for initialization
    void Start ()
    {
        Instance = this;

        for (int i = 0; i < transform.childCount; i++)
        {
            m_Backgrounds.Add(transform.GetChild(i).gameObject);
        }

        number = m_Backgrounds.Count;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ScrollNow();
        }
    }

    public void ScrollNow()
    {
        if (index > (m_Backgrounds.Count - 1))
        {
            index = 0;
        }

        m_Backgrounds[index].transform.position = new Vector3((m_Backgrounds[index].GetComponent<Renderer>().bounds.size.x * number), 0, 0);
        number++;
        index++;
    }
}
