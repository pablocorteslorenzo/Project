using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public GameObject GameObject;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				GameObject = hit.transform.gameObject;
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			GameObject = null;
		}
	}
}
