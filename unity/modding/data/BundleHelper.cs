using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200091F RID: 2335
public class BundleHelper
{
	// Token: 0x06002D0D RID: 11533 RVA: 0x000B0E08 File Offset: 0x000AF008
	public static AssetBundle LoadIfNotLoaded(string name)
	{
		name = name.Replace('\\', '/');
		if (BundleHelper.bundles.ContainsKey(name))
		{
			return BundleHelper.bundles[name];
		}
		Console.WriteLine("Loading bundle " + name + " for the first time.");
		AssetBundle assetBundle = AssetBundle.LoadFromFile(name);
		BundleHelper.bundles[name] = assetBundle;
		return assetBundle;
	}

	// Token: 0x04002144 RID: 8516
	public static Dictionary<string, AssetBundle> bundles = new Dictionary<string, AssetBundle>();

	// Token: 0x04002145 RID: 8517
	public static string AssetBundlePath = "ModData/Bundles/";
}
