using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{
	// キューブの移動速度
	private float m_fSpeed = -0.2f;
	// 消滅位置
	private float m_fDeadLine = -10;
	// キューブ音
	private AudioSource m_AudioSource;

	// Use this for initialization
	void Start()
	{
		m_AudioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		// キューブを移動させる
		transform.Translate(m_fSpeed, 0, 0);

		// 画面外に出たら破棄する
		if (transform.position.x < m_fDeadLine)
		{
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Block" || 
			collision.gameObject.name == "ground")
		{
			m_AudioSource.Play();
		}
	}
}