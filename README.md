# [School Project] VikingRun
[RepoLink](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity)
| https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity

## Index
* [Assets](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/tree/master/Assets)
  * [Animation](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/tree/master/Assets/Animation)
  * [Input](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/tree/master/Assets/Input)
  * [Prefabs](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/tree/master/Assets/Prefabs)
  * [Scenes](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/tree/master/Assets/Scenes)
  * [Scripts](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/tree/master/Assets/Scripts)
  
## About
![Icon](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/blob/master/ProgramPhoto/VikingIcon.png)
</br>
This is a game which likes "TempleRun", players goal is to collect high scores(Shield) and survival for a long time.

## How To Play
<p>
Forward : Press W <br>
Left : Press A <br>
Right : Press D <br>
Jump : Press Space <br>
Rotate Left : Press Q <br>
Rotate Right : Press E
</p>

## Technical

### Player

#### State Machine
Flow of player will use finite state machine.
![PlayerStateMachineDiagram](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/blob/master/ProgramPhoto/PlayerStateMachineDiagram.png)
> [PlayerStateMachine](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/tree/master/Assets/Scripts/PlayerStateMachineScripts)

#### Data
Store Alive Status, Scores and Survival Time with Model. <br>
Pattern : Model , View Model, IObservable. <br>
![PlayerDataFlow](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/blob/master/ProgramPhoto/PlayerDataFlow.png)
>[Model](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/tree/master/Assets/Scripts/DataModels)
| [View Model](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/tree/master/Assets/Scripts/ViewModel)
| [IObservable](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/tree/master/Assets/Scripts/Interface)

### Enemy

#### State Machine
Flow of player will use finite state machine.<br>
![EnemyStateMachine](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/blob/master/ProgramPhoto/EnemyStateMachineDiagram.png)
>[EnemyStateMachine](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/tree/master/Assets/Scripts/EnemyStateMachineScripts)

### Map

This game will have four different structures of the road, Straight, Left, Right and Jump.<br>
All roads will generate one by one without sequences.
>[RoadPrefabs](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/tree/master/Assets/Prefabs/Road)
| [GroundSpawn](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/blob/master/Assets/Scripts/TerrainScripts/GroundSpawner.cs)

#### Ground Obstacles
Two types of obstacles spawner used in the game, Bridge and Middle platform.
>[BridgeObstacleSpawner](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/blob/master/Assets/Scripts/TerrainScripts/GroundObstacleSpawner.cs)
| [PlatformObstacleSpawner](https://github.com/UncleThree0402/SchoolProject_VikingRun_Unity/blob/master/Assets/Scripts/TerrainScripts/PlatObstaclerSpawner.cs)