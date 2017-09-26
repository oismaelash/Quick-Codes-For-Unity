using UnityEngine;

public class CollisionWithoutPhysics : MonoBehaviour
{
    void Update ()
    {
        CheckingCollision();
    }

    private void CheckingCollision()
    {
        Enemy[] enemys = FindObjectsOfType(typeof(Enemy)) as Enemy[]; // Get type or tag of GameObjects

		foreach(Enemy enemy in enemys)
        {
			float distance = Vector3.Distance(enemy.gameObject.transform.position, this.transform.position); // Checking distance of GameObjetcs

            if (distance < 1.01f) // Distance of collision for detection
            {
                print("Your code");
            }
        }
    }
}
