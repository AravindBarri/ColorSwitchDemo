using UnityEngine;
using UnityEngine.SceneManagement;

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
}
