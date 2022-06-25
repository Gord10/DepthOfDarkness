using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	protected static T _instance;

	public static T Instance
	{
		get
		{
			if(!_instance)
            {
				_instance = GameObject.FindObjectOfType<T>();
			}
			return _instance;
		}
	}

	protected virtual void Awake()
	{
		_instance = gameObject.GetComponent<T>();
	}
}