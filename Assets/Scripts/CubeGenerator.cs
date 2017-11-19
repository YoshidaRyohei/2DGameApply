using UnityEngine;
using System.Collections;

public class CubeGenerator : MonoBehaviour
{
	// キューブのPrefab
	[SerializeField]
	private GameObject m_CubePrefab;

	// 時間計測用の変数
	private float m_fDeltaTime = 0;

	// キューブの生成間隔
	private float m_fSpan = 1.0f;

	// キューブの生成位置：X座標
	private float m_fGenPosX = 12;

	// キューブの生成位置オフセット
	private float m_fOffsetY = 0.3f;
	// キューブの縦方向の間隔
	private float m_fSpaceY = 6.9f;

	// キューブの生成位置オフセット
	private float m_fOffsetX = 0.5f;
	// キューブの横方向の間隔
	private float m_fSpaceX = 0.4f;

	// キューブの生成個数の上限
	private int m_nMaxBlockNum = 4;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		m_fDeltaTime += Time.deltaTime;

		// span秒以上の時間が経過したかを調べる
		if (m_fDeltaTime > m_fSpan)
		{
			m_fDeltaTime = 0;
			// 生成するキューブ数をランダムに決める
			int n = Random.Range(1, m_nMaxBlockNum + 1);

			// 指定した数だけキューブを生成する
			for (int i = 0; i < n; i++)
			{
				// キューブの生成
				GameObject go = Instantiate(m_CubePrefab) as GameObject;
				go.transform.position = new Vector2(m_fGenPosX, m_fOffsetY + i * m_fSpaceY);
				go.transform.parent = transform;
			}
			// 次のキューブまでの生成時間を決める
			m_fSpan = m_fOffsetX + m_fSpaceX * n;
		}
	}
}