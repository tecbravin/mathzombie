using System;

namespace TowerDefense.Game
{
	/// <summary>
	/// A calss to save level data
	/// </summary>
	[Serializable]
	public class LevelSaveData
	{
		public string id;
		public int numberOfStars;
		public int points;

		public LevelSaveData(string levelId, int numberOfStarsEarned, int pts)
		{
			id = levelId;
			numberOfStars = numberOfStarsEarned;
			points = pts;
		}
	}
}