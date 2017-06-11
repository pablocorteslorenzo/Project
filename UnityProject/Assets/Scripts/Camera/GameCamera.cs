using UnityEngine;
using Game;

public class GameCamera : MonoBehaviour
{
	private Transform m_transform;

	public Transform Target;
	public Vector3 Position;

	private void Awake()
	{
		m_transform = GetComponent<Transform>();
		Position = m_transform.position;
	}

	public void Update()
	{
		if (Target == null && World.isSet && World.Instance.Player != null)
		{
			Target = World.Instance.Player.transform;
		}
		if (Target != null)
		{
			m_transform.position = Target.position + Position;
		}
	}
}
