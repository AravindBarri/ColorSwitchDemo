using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Player : MonoBehaviour {

	public float jumpForce = 10f;

	public Rigidbody2D rb;
	public SpriteRenderer sr;

	public string currentColor;

	public Color colorCyan;
	public Color colorYellow;
	public Color colorMagenta;
	public Color colorPink;

	ScoreManager scoreObject;
	public static Player instance;
	public int score = 0;
    private void Awake()
    {
		instance = this;
    }

    void Start ()
	{
		SetRandomColor();
		scoreObject = GameObject.Find("ScoreText").GetComponent<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
			rb.velocity = Vector2.up * jumpForce;
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "ColorChanger")
		{
			SetRandomColor();
			col.gameObject.SetActive(false);
			GameObject other = col.gameObject;
			GameObject otherParent = other.transform.parent.gameObject;
			ObstacleManager.Instance.AddToPool(otherParent);
			col.gameObject.SetActive(true);
			scoreObject.updateScore();
			SaveData();
			return;
		}
		else if(col.tag == "None")
        {
			return;
        }
		if (col.tag != currentColor)
		{
			Debug.Log("GAME OVER!");
			SceneManager.LoadScene(3);

		}
	}

	void SetRandomColor ()
	{
		int index = Random.Range(0, 4);
		ObstacleManager.Instance.SpawnObstacle();
		switch (index)
		{
			case 0:
				currentColor = "Cyan";
				sr.color = colorCyan;
				break;
			case 1:
				currentColor = "Yellow";
				sr.color = colorYellow;
				break;
			case 2:
				currentColor = "Magenta";
				sr.color = colorMagenta;
				break;
			case 3:
				currentColor = "Pink";
				sr.color = colorPink;
				break;
		}
	}
	public void SaveData()
	{
		string filePath = UnityEngine.Application.persistentDataPath + "/PlayerScore.file";
		FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
		BinaryWriter bw = new BinaryWriter(fs);
		bw.Write(ScoreManager.instance.score);
		fs.Close();
		bw.Close();
	}
}
