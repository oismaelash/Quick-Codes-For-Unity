using System.Collections.Generic;
using UnityEngine;

public class RandomNumbers : MonoBehaviour
{
    [SerializeField]
    private List<int> numbersCreated;
    [Space]
    [SerializeField] private int countNumberCreate = 10;

    [ContextMenu("CallGenerateRandomNumbers")]
    private void CallGenerateRandomNumbers()
    {
        numbersCreated = new List<int>();

        for (int i = 0; i < countNumberCreate; i++)
            GenerateRandomNumbers();

        numbersCreated.Sort();
    }

    private void GenerateRandomNumbers()
    {
        int newNumber = Random.Range(-10, 10);

        if (numbersCreated.Contains(newNumber))
            GenerateRandomNumbers();
        else
            numbersCreated.Add(newNumber);
    }
}
