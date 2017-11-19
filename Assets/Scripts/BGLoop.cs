using UnityEngine;
using System.Collections;

public class BGLoop : MonoBehaviour
{
	// スクロール速度
	private float m_fScrollSpeed = -0.03f;
	// 背景終了位置
	private float m_fDeadLine = -18.5f;
	// 背景開始位置
	private float m_fStartLine = 18.8f;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		// 背景を移動する
		transform.Translate(m_fScrollSpeed, 0, 0);

		// 画面外に出たら、画面右端に移動する
		if (transform.position.x < m_fDeadLine)
		{
			transform.position = new Vector2(m_fStartLine, 0);
		}
	}
}