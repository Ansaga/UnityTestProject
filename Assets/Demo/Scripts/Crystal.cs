using UnityEngine;

public class Crystal : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}
}
