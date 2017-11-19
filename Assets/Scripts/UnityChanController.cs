using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UnityChanController : MonoBehaviour {
	#region プロパティ
	/// <summary>
	/// アニメーション管理コンポーネント
	/// </summary>
	private Animator m_Animator;
	/// <summary>
	/// 物理挙動管理コンポーネント
	/// </summary>
	private Rigidbody2D m_Rigidbody;
	/// <summary>
	/// ゲームオーバー表示用UI管理クラス
	/// </summary>
	[SerializeField]
	private UIManager m_UIManager;
	/// <summary>
	/// 足音
	/// </summary>
	private AudioSource m_AudioSource;
	/// <summary>
	/// ジャンプ速度の減衰率
	/// </summary>
	private const float m_fDump = 0.8f;
	/// <summary>
	/// ジャンプ速度
	/// </summary>
	private const float m_fJumpVelocity = 20f;
	/// <summary>
	/// 地面の位置
	/// </summary>
	private const float m_fGroundLevel = -3.0f;
	/// <summary>
	/// ゲームオーバーになる位置
	/// </summary>
	private const float m_fGameOverLine = -9f;
	#endregion

	void Start()
	{
		m_Animator = GetComponent<Animator>();
		m_Rigidbody = GetComponent<Rigidbody2D>();
		m_AudioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		// 走るアニメーションを再生するために、Animatorのパラメータを調節する
		m_Animator.SetFloat("Horizontal", 1);

		// 着地しているかどうかを調べる
		bool isGround = (transform.position.y > m_fGroundLevel) ? false : true;
		m_Animator.SetBool("isGround", isGround);
		m_AudioSource.volume = (isGround) ? 1 : 0;

		// 着地状態でクリックされた場合
		if (Input.GetMouseButtonDown(0) && isGround)
		{
			// 上方向の力をかける
			m_Rigidbody.velocity = new Vector2(0, m_fJumpVelocity);
		}

		// クリックをやめたら上方向への速度を減速する
		if (Input.GetMouseButton(0) == false)
		{
			if (m_Rigidbody.velocity.y > 0)
			{
				m_Rigidbody.velocity *= m_fDump;
			}
		}

		// デッドラインを超えた場合ゲームオーバにする
		if (transform.position.x < m_fGameOverLine)
		{
			// UIManagerのGameOver関数を呼び出して画面上に「GameOver」と表示する
			m_UIManager.GameOver();

			// ユニティちゃんを破棄する（追加）
			Destroy(gameObject);
		}
	}
}
