using System;
using TMPro;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class Game : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002078 File Offset: 0x00000278
	private void Start()
	{
		this.score = 0;
		this.GetNewFlag();
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002244 File Offset: 0x00000444
	private void GetNewFlag()
	{
		int num = UnityEngine.Random.Range(0, this.flagObjects.Length);
		GameObject gameObject = this.flagObjects[num];
		this.flag = gameObject.name;
		string text = this.flag;
		char c = char.ToUpper(text[0]);
		text = text.Remove(0, 1);
		this.time = ConfigHelper.GetInt("ModData/config.cfg", "maxtime");
		this.deltaTime = 0f;
		this.title.text = string.Concat(new string[]
		{
			"Find the flag ",
			c.ToString(),
			text,
			string.Format(". Your score is {0}.", this.score),
			string.Format(" Time: {0}", this.time)
		});
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002087 File Offset: 0x00000287
	public void OnClick(string flagName)
	{
		if (flagName == this.flag)
		{
			this.score++;
		}
		this.GetNewFlag();
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002310 File Offset: 0x00000510
	private void Update()
	{
		this.deltaTime += Time.deltaTime;
		if (this.deltaTime >= 1f)
		{
			this.time--;
			this.deltaTime = 0f;
		}
		if (this.time <= 0)
		{
			this.time = 0;
			this.GetNewFlag();
		}
		string text = this.flag;
		char c = char.ToUpper(text[0]);
		text = text.Remove(0, 1);
		this.title.text = string.Concat(new string[]
		{
			"Find the flag ",
			c.ToString(),
			text,
			string.Format(". Your score is {0}.", this.score),
			string.Format(" Time: {0}", this.time)
		});
	}

	// Token: 0x04000001 RID: 1
	private string flag;

	// Token: 0x04000002 RID: 2
	private int score;

	// Token: 0x04000003 RID: 3
	public TextMeshProUGUI title;

	// Token: 0x04000004 RID: 4
	public GameObject[] flagObjects;

	// Token: 0x04000005 RID: 5
	private int time;

	// Token: 0x04000006 RID: 6
	private float deltaTime;
}
