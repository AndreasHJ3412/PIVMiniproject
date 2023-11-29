# PIVMiniproject

![Visual](https://github.com/AndreasHJ3412/PIVMiniproject/blob/main/Gameplay/Gameplay.gif)

## Overview of the Game
The idea for the project is based on a first-person shooter where time slows down when the player is stationary but runs in real-time during movement. Player moves through an enclosed arena while fighting with enemies who run towards and shoot at the player. The enemies shooting after the player is static in one place, and when the bullets from the shooting enemy hits the player, the player’s health decreases. The enemies running towards the player is chasing with different speed, so the player needs to figure out which enemies is prioritised to shoot. Also, if the chasing enemies hits the player only once, the level restarts. 
There are two levels:  
- First level with less bullets and health but also less enemies to shoot. And if the player runs out of bullets, there is weapons laying around the map that can be picked up. 
- The second level is a bit more difficult. Here there is more enemies including a boss enemy with 10x more health than the normal enemies. But in level 2 the player also has more bullets and there more weapons laying around ready to be picked up if the player runs out of bullets. 

The main parts of the game are:
- Player: Controlled in first-person view using keyboard controls (WASD). 
- Camera: Allows rotation around the level using the mouse. 
- Objective: The goal is to kill all enemies and not let them kill you first. 
- Enemies: Spawned in areas across the level. They give damage upon hitting or shooting the player. 
- Playfield: There are two levels with two different terrain types. One with mountains and snow and the other with grass and hills. 
- Health: Starting with full health, lose all health and the game ends. 

Game features:
- Times only moves in real time when the player is moving. 
- The player can move freely around the level area.
- The player can shoot enemies with weapons.
- Soundtrack is playing to set the tone of the game. 

## Project Parts

### Scripts
- PlayerMovement – used for controlling the gametime to simulate the slow-motion effect and for moving the character using rigidbody physics and rotate the movement based on camera position. Also controls the background soundtrack.
- GunEnemies – used for the static placed enemies with guns for looking at and shooting instantiated bullets after the player.
- Gun – used on the player to keep track on the player’s gun and instantiating bullets when the player is shooting.
- Level1EnemyBullet – used on the Level1EnemyBullet prefab. It is controlling the health bar whenever the player is hit by a bullet. The Level1EnemyBullet is dealing 25 damage when the player is hit.
- Level2EnemyBullet – almost the exact same as for level 1, but for level 2. This time the Level2EnemyBullet deals 10 damage when the player is hit.
- Level1EnemyMovement – sits on the level 1 enemies controlling the NavMeshAgent. When the player is in a given radius of the enemy, the enemy will chase the player. If the player is hit, level 1 is set to restart.
- Level2EnemyMovement – The same as for level 1. Just controlling the enemies in level 2. If the player is hit, level 2 is set to restart.
- Level1Explosion – sits on the level 1 enemies. When the enemies are hit with a bullet from the player, the enemies will die and “transformed” into small cubes with an explosion force, explosion radius and explosion upwards force.
- Level2Explosion – the same as for level 1.
- Level1KillCount – controls the UI. Shows and controls the bullets and kills and if the max kills are hit, the next level will start.
- Level2KillCount – controls the UI for level 2. Here there is just a bit more bullets and requires more kills to win.
- Level1PickUpWeapon – used for picking up and dropping weapons. Also sets the weapons in the correct position when picking up the weapons. If the player runs out of bullets, the weapon is automatically dropped, and the player needs to look for the next weapon to pick up that has more bullets. It also controls the bullets from the “KillCounter” script.
- Level2PickUpWeapon – used for the same as in level 1. This time it controls the UI from level 2.
- Big enemy explosion – This is only used in level 2. It is for the boss enemy. It is controlling the explosion for the boss enemy, which is only supposed to die and explode after getting hit 10 times. 

### Models & Prefabs
- A model of the skybox downloaded from https://polyhaven.com/a/kloofendal_48d_partly_cloudy_puresky?fbclid=IwAR0RRCbCvSkkSn8Hz70O0ZNZDo5IeOzVYqLZ5qoYy7OWP8jZUvnGL5-mMGo
- Weapons, buildings, enemies, UI and bullets are made with Unity primitives.
- Levels are created with Terrain Tools - https://docs.unity3d.com/Packages/com.unity.terrain-tools@5.0/manual/terrain-toolbox.html?q=terrain
- Level textures and grass prefabs from https://assetstore.unity.com/packages/3d/environments/landscapes/terrain-sample-asset-pack-145808  

Materials: 
- Basic Unity materials for weapons, building, player, enemies and bullets 

Scenes: 
- Game consists of three scenes. “Level 1”, “Level 2” and a “Victory scene”. 

Testing: 
- The game was tested on Windows, the game cannot be currently played on a mobile platform. 

| **Task**                                                                | **Time it Took (in hours)** |
|--------------------------------------------------------------------------------|------------------------------------|
|     Setting up   Unity, making a project in GitHub                             |     0.5                            |
|     Research of game idea                                                      |     0.5                            |
|     Setting up NavMeshAgents                                                   |     1                              |
|     Making 3D models in Unity – Buildings, enemies, weapons, bullets           |     1                              |
|     Finding and making materials                                               |     0.5                            |
|     Player and camera movement – including slow-motion effect                  |     1                              |
|     Making levels with Terrain Tools – Level 1 and 2                           |     2                              |
|    Placing every weapon, buildings and enemies across the levels               |     1                              |
|    Fixing errors with the code or Unity project                                |     3                              |
|    Making UI and setting it up in the code                                     |     1.5                            |
|    Overall adjustments and further development of the project                  |     3                              |
|    Bug fixing                                                                  |     4                              |
|     Code   documentation                                                       |     1                              |
|     Making readme                                                              |     0.5                            |
|     **All**                                                                    |     **20.5**                       |

## References
[The skybox] - https://polyhaven.com/a/kloofendal_48d_partly_cloudy_puresky?fbclid=IwAR0RRCbCvSkkSn8Hz70O0ZNZDo5IeOzVYqLZ5qoYy7OWP8jZUvnGL5-mMGo  

[Terrain Tool] - https://docs.unity3d.com/Packages/com.unity.terrain-tools@5.0/manual/terrain-toolbox.html?q=terrain 

[StarterAssets – FirstPerson] - https://assetstore.unity.com/packages/essentials/starterassets-firstperson-updates-in-new-charactercontroller-pac-196525  

[Terrain Sample Asset Pack] - https://assetstore.unity.com/packages/3d/environments/landscapes/terrain-sample-asset-pack-145808  

[How To Create A Slow Motion Effect Like SUPERHOT | Unity C# Tutorial] - https://www.youtube.com/watch?v=FCEYQpAC-4Q  

[Enemy Shooting Bullets at player in unity | Navmesh] - https://www.youtube.com/watch?v=nE-YBeCSf68  

[FULL PICK UP & DROP SYSTEM for WEAPONS or ITEMS || Unity3d Tutorial] - https://www.youtube.com/watch?v=8kKLUsn7tcg  

[Unity C# Coding Practices #1, Destroy a cube into pieces] - https://www.youtube.com/watch?v=s_v9JnTDCCY  
