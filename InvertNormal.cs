using UnityEngine;

public class InvertNormalSphere : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        Vector3[] normalsInvert = mesh.normals;

        for(int i = 0; i < normalsInvert.Length; i++)
        {
            normalsInvert[i] = -1 * normalsInvert[i];
        }

        mesh.normals = normalsInvert;

        for(int i = 0; i < mesh.subMeshCount; i++)
        {
            int[] tris = mesh.GetTriangles(i);

            for(int j = 0; j < tris.Length; j+=3)
            {
                int temp = tris[j];
                tris[j] = tris[j + 1];
                tris[j + 1] = temp;
            }

            mesh.SetTriangles(tris, i);
        }
	}
}
