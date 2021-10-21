
namespace Enumerations
{
    public enum AnimalRarity { Common, Uncommon, Rare, SuperRare, UltraRare, Mythical }

    public enum GameScene { Start, MainMenu, Maze, TutorialMaze, Shop, Album }

    public enum PlayFabAPICallType { Login, PlayFabSync, ResolveRescueOperation, LoadingPlayerInventory, LoadingStore, RecoverableAccountSetup, UnlinkAccount, GeneratingRescueOperation, UsingAbilityOrb, GettingStatistics, GettingAnimals, GettingAds, ReportingAds, RewardingAds, UsingSkip, RedeemPromoCode, GetLeaderboards, ClaimDailyTaskReward, GetPlayerLeaderboard, SpinTheWheel, ClaimWheelReward }

    public enum RecoverableAccountErrorType { InvalidEmail, InvalidPassword, InvalidUsername, UsernameNotAvailable, EmailNotAvailable, NoError, InvalidParams, AccountNotFound, InvalidUsernameOrPassword }

    public enum MiniGameParameterType { NumberOfBoards, ShuffleNumberOfTiles, NumberOfMoves, MazeDimension, NumberOfMazeEnemyAttacks }

    public enum PlayFabControllerTasks { FetchAbilityOrbRepositoryData, FetchRoRepositoryData, FetchPlayerLevelInformation, FetchUnlockedAnimals, ResolveRO, FetchAds, ReportingAdActivity, RewardingAdActivity, FetchDailyRewardsBoard, FetchNewUnlockedRarity, UsingAbilityOrb, UsingSkipOrb, RedeemingPromoCode, FetchDailyTasks, RefreshDailyTasks, ClaimingDailyTaskReward, GetCurrentWheelData, SpinTheWheel, ClaimWheelReward }

    public enum GameProgressTasks { Initialization, PlayerLevelInformationRefresh, FetchNewRescueOperation, ReinitializeAbilityOrbRepository }

    public enum AbilityOrbRepositoryTasks { Initialization, UseOrb, RefreshOrbs, RefreshApAmount }

    public enum DynamicDataIOTasks { AbilityOrbRepositoryDataLoading, UnlockedAnimalsDataLoading, ActiveRescueOperationDataLoading, PlayerLevelInformationDataLoading, NewAbilityOrbsDataLoading, NewUnlockedAnimalsDataLoading, DailyRewardsBoardDataLoading, LastRescueOperationUnlocksDataLoading, FetchRedeemPromoCodeResult, DailyTasksDataLoading, ClaimDailyTaskReward, UseAbilityOrb, UseSkipOrb, RescueOperationRepositoryDataLoading, ResolvingRO, LoadingCurrentWheel, SpinningTheWheel, ClaimingWheelReward }

    public enum SfxType { UiConfirm, UiCancel, Footsteps, Land, BalloonsOpen, BalloonsClose, Explosion, Teleport, Dissolve, Fireworks, Success, Failure, Steam, AbilityOrbGlow, Fairy, MoveAir, Waterfall }

    public enum GameSceneType { MainMenu, Album, Memory, TutorialMemory, Store, StartScene, AdMobTestScene, DailyTaksTestScene }

    public enum DailyRewardType { AP, SO, FO }

    public enum AdType { None, AddMovesAd, BannerAd, SkipRescueOperationAd, ClaimAp_1, ClaimAp_2, ClaimAp_3, ClaimAp_4, InterstatialAd, WheelRespinAd }

    public enum MemoryPowerUp { ShowRow, ShowColumn, Hint, Reveal, AddMoves }

    public enum MemoryDynamicElementType { MainCharacter, Companion, Villan, MemoryBoard }

    public enum GenericBannerPosition { Top, Bottom }

    public enum DailyTasksRepositoryTasks { Initialization, Refresh, ClaimingReward }

    public enum RescueOperationRepositoryTasks { Initialization, ResolvingRescueOperation }

    public enum SpinTheWheelTasks { Initialization, Spin, ClaimReward }
}

