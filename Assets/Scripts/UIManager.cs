using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	/// <summary>
	/// ゲームオーバーテキスト
	/// </summary>
	[SerializeField]
	private Text m_GameOverText;
	/// <summary>
	/// 走った距離テキスト
	/// </summary>
	[SerializeField]
	private Text m_RunLengthText;
	/// <summary>
	/// 走った距離
	/// </summary>
	private float m_fRunLength;

	/// <summary>
	/// 走る速度
	/// </summary>
	private const float m_fRunSpeed = 0.03f;
	/// <summary>
	/// ゲームオーバーフラグ
	/// </summary>
	private bool m_bGameOver;

	// Use this for initialization
	void Start ()
	{
		m_fRunLength = 0.0f;
		m_bGameOver = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!m_bGameOver)
		{
			// 走った距離を更新する
			m_fRunLength += m_fRunSpeed;

			// 走った距離を表示する
			m_RunLengthText.text = "Distance:  " + m_fRunLength.ToString("F2") + "m";
		}
		else
		{
			// クリックされたらシーンをロードする
			if (Input.GetMouseButtonDown(0))
			{
				// 今と同じシーンを読み込む
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}

	}
	public void GameOver()
	{
		// ゲームオーバになったときに、画面上にゲームオーバを表示する
		m_GameOverText.text = "GameOver";
		m_bGameOver = true;
	}
}
