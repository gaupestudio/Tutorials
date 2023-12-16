using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

// Token: 0x0200091C RID: 2332
public class ConfigHelper
{
	// Token: 0x06002CF8 RID: 11512 RVA: 0x0001F0F6 File Offset: 0x0001D2F6
	public static ConfigHelper.ConfigFile GetFile(string fileName)
	{
		fileName = fileName.Replace('\\', '/');
		if (ConfigHelper.configs.ContainsKey(fileName))
		{
			return ConfigHelper.configs[fileName];
		}
		return ConfigHelper.InitializeFile(fileName);
	}

	// Token: 0x06002CF9 RID: 11513 RVA: 0x000B09B4 File Offset: 0x000AEBB4
	public static ConfigHelper.ConfigFile InitializeFile(string fileName)
	{
		Console.WriteLine("Loading " + fileName + " for the first time");
		CultureInfo.CurrentCulture = new CultureInfo("en-US");
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
		Dictionary<string, float> dictionary3 = new Dictionary<string, float>();
		Dictionary<string, Vector3> dictionary4 = new Dictionary<string, Vector3>();
		StreamReader streamReader = new StreamReader(fileName);
		string text;
		while ((text = streamReader.ReadLine()) != null)
		{
			if (text.Length != 0 && text[0] != '#')
			{
				string[] array = text.Split(new char[]
				{
					' '
				});
				if (array.Length != 3)
				{
					Console.WriteLine(string.Concat(new string[]
					{
						"Invalid number of parameter on line ",
						text,
						" in file ",
						fileName,
						"."
					}));
				}
				else if (array[0] == "string")
				{
					dictionary.Add(array[1], array[2]);
				}
				else
				{
					if (array[0] == "int")
					{
						try
						{
							dictionary2.Add(array[1], int.Parse(array[2]));
							continue;
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
							Console.WriteLine("On " + array[2]);
							dictionary2.Add(array[1], 0);
							continue;
						}
					}
					if (array[0] == "float")
					{
						try
						{
							dictionary3.Add(array[1], float.Parse(array[2]));
							continue;
						}
						catch (Exception ex2)
						{
							Console.WriteLine(ex2.Message);
							Console.WriteLine("On " + array[2]);
							dictionary3.Add(array[1], 0f);
							continue;
						}
					}
					if (array[0] == "vec3")
					{
						try
						{
							string[] array2 = array[2].Split(new char[]
							{
								','
							});
							if (array2.Length != 3)
							{
								Console.WriteLine(string.Concat(new string[]
								{
									"Invalid number of values on line ",
									text,
									" in file ",
									fileName,
									"."
								}));
							}
							else
							{
								array2[0].Trim();
								array2[1].Trim();
								array2[2].Trim();
								dictionary4.Add(array[1], new Vector3(float.Parse(array2[0]), float.Parse(array2[1]), float.Parse(array2[2])));
							}
							continue;
						}
						catch (Exception ex3)
						{
							Console.WriteLine(ex3.Message);
							Console.WriteLine("On " + array[2]);
							dictionary4.Add(array[1], default(Vector3));
							continue;
						}
					}
					Console.WriteLine(string.Concat(new string[]
					{
						"Data type ",
						array[0],
						" not found in file ",
						fileName,
						"."
					}));
				}
			}
		}
		ConfigHelper.ConfigFile configFile = new ConfigHelper.ConfigFile(dictionary, dictionary2, dictionary3, dictionary4);
		ConfigHelper.configs.Add(fileName, configFile);
		return configFile;
	}

	// Token: 0x06002CFA RID: 11514 RVA: 0x000B0CAC File Offset: 0x000AEEAC
	public static string GetString(string configName, string valName)
	{
		string result;
		try
		{
			result = ConfigHelper.GetFile(configName).GetString(valName);
		}
		catch
		{
			Console.WriteLine("(str)Unable to get config value (or could be bad assignment)" + valName.ToString() + " from " + configName.ToString());
			result = null;
		}
		return result;
	}

	// Token: 0x06002CFB RID: 11515 RVA: 0x000B0D00 File Offset: 0x000AEF00
	public static int GetInt(string configName, string valName)
	{
		int result;
		try
		{
			result = ConfigHelper.GetFile(configName).GetInt(valName);
		}
		catch
		{
			Console.WriteLine("(int)Unable to get config value (or could be bad assignment)" + valName.ToString() + " from " + configName.ToString());
			result = 0;
		}
		return result;
	}

	// Token: 0x06002CFC RID: 11516 RVA: 0x000B0D54 File Offset: 0x000AEF54
	public static float GetFloat(string configName, string valName)
	{
		float result;
		try
		{
			result = ConfigHelper.GetFile(configName).GetFloat(valName);
		}
		catch
		{
			Console.WriteLine("(float)Unable to get config value (or could be bad assignment) " + valName.ToString() + " from " + configName.ToString());
			result = 0f;
		}
		return result;
	}

	// Token: 0x06002CFD RID: 11517 RVA: 0x0001F123 File Offset: 0x0001D323
	public static Vector3 GetVec3(string configName, string valName)
	{
		return ConfigHelper.GetFile(configName).GetVec3(valName);
	}

	// Token: 0x06002D00 RID: 11520 RVA: 0x0001F131 File Offset: 0x0001D331
	public static void Reset()
	{
		ConfigHelper.configs = new Dictionary<string, ConfigHelper.ConfigFile>();
	}

	// Token: 0x0400213F RID: 8511
	private static Dictionary<string, ConfigHelper.ConfigFile> configs = new Dictionary<string, ConfigHelper.ConfigFile>();

	// Token: 0x0200091D RID: 2333
	public class ConfigFile
	{
		// Token: 0x06002D01 RID: 11521 RVA: 0x0001F13D File Offset: 0x0001D33D
		public ConfigFile()
		{
		}

		// Token: 0x06002D02 RID: 11522 RVA: 0x000B0DAC File Offset: 0x000AEFAC
		public ConfigFile(Dictionary<string, string> sStrings, Dictionary<string, int> sInts, Dictionary<string, float> sFloats, Dictionary<string, Vector3> sVecs)
		{
			this.sStrings = sStrings;
			this.sInts = sInts;
			this.sFloats = sFloats;
			this.sVecs = sVecs;
		}

		// Token: 0x06002D03 RID: 11523 RVA: 0x0001F171 File Offset: 0x0001D371
		public string GetString(string valName)
		{
			return this.sStrings[valName];
		}

		// Token: 0x06002D04 RID: 11524 RVA: 0x0001F17F File Offset: 0x0001D37F
		public int GetInt(string valName)
		{
			return this.sInts[valName];
		}

		// Token: 0x06002D05 RID: 11525 RVA: 0x0001F18D File Offset: 0x0001D38D
		public float GetFloat(string valName)
		{
			return this.sFloats[valName];
		}

		// Token: 0x06002D06 RID: 11526 RVA: 0x0001F19B File Offset: 0x0001D39B
		public Vector3 GetVec3(string valName)
		{
			return this.sVecs[valName];
		}

		// Token: 0x06002D07 RID: 11527 RVA: 0x0001F1A9 File Offset: 0x0001D3A9
		public void AddExternalValue(string valName, string value)
		{
			if (this.sStrings.ContainsKey(valName))
			{
				return;
			}
			this.sStrings.Add(valName, value);
		}

		// Token: 0x06002D08 RID: 11528 RVA: 0x0001F1C7 File Offset: 0x0001D3C7
		public void AddExternalValue(string valName, int value)
		{
			if (this.sInts.ContainsKey(valName))
			{
				return;
			}
			this.sInts.Add(valName, value);
		}

		// Token: 0x06002D09 RID: 11529 RVA: 0x0001F1E5 File Offset: 0x0001D3E5
		public void AddExternalValue(string valName, float value)
		{
			if (this.sFloats.ContainsKey(valName))
			{
				return;
			}
			this.sFloats.Add(valName, value);
		}

		// Token: 0x06002D0A RID: 11530 RVA: 0x0001F203 File Offset: 0x0001D403
		public void AddExternalValue(string valName, Vector3 value)
		{
			if (this.sVecs.ContainsKey(valName))
			{
				return;
			}
			this.sVecs.Add(valName, value);
		}

		// Token: 0x04002140 RID: 8512
		private Dictionary<string, string> sStrings = new Dictionary<string, string>();

		// Token: 0x04002141 RID: 8513
		private Dictionary<string, int> sInts = new Dictionary<string, int>();

		// Token: 0x04002142 RID: 8514
		private Dictionary<string, float> sFloats = new Dictionary<string, float>();

		// Token: 0x04002143 RID: 8515
		private Dictionary<string, Vector3> sVecs = new Dictionary<string, Vector3>();
	}
}