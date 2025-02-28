using Blast.DataTypes;
using UnityEngine;

namespace Blast.DataLayer.Metadata
{
	public interface IGameMetadata
	{
		Object GetPrefabForCannon(PlayerCannonType playerCannonType);
		
		GameLevelMetadata GetLevelMetadata(GameLevelType levelType);
		
		InfraScreenMetadata GetInfraScreenMetadata(InfraScreenType screenType);
		GameLevelMetadata[] GetLevelsMetadata();
	}
}