# Udacity VR: the 6th project - Rube Goldberg Game
This is 6th project for Udacity' VR Nanodegree. This project is one of Multi-VR-HMD(Head Mount Device) supported High Immersion VR Projects at Udacity by Steam VR; SteamVR based Open VR High Immersion Head Mount Devices such as Oculus' Rift and VIVE's HTC. Base on Oculus' Rift HMD with Unity, I have developed Rube Goldberg Puzzle Game.
![screenshot](https://github.com/himax25/RubeGoldbergGameVR-HMD-/blob/master/Game%20Screenshot1.PNG)

## Rube Goldberg Game: consists of 4 levels with High Immersion VR based puzzle game.
The player needs to build up his or her own ball rolling journey to the goal gate with 4 difference game objects by the game menu. In each level, there have different layouts for both factorial structure and teleport gateways, and a limited number of game-object to choose. The winning condition of this game is how long the ball takes to get thru the goal gate and how many stars the ball takes in its ball rolling journey.
![youtubelink](https://github.com/himax25/RubeGoldbergGameVR-HMD-/blob/master/Screenshot%20of%20Youtube.PNG)[for playing Youtube video here](https://youtu.be/R6i4eu5UBbI)

# Design and Deployment
Building up Rube Goldberg Ball rolling journey from Playing Start platform to the Goal gate by Game Object puzzled location with Teleports. The player will get essential score points thru 10 stars to collect on its ball path with execution time at each level.

## Movement Control
SteamVR based management supports multi High Immersion Head Mount Device with controlles such as VIVE HTC and Oculus Rift.
* Left Controller: control teleport and locomotion.
>> <li><b>Trigger button hold/release</b>: Teleport to TeleportAimer. </li>
>> <li><b>Grip button holdding</b>: Walking locomotion. </li>
* Right Contoller: Game Object Menu and Ball control. </li>
>> <li><b>Touchpad(Swipping L/R)</b>: Show objects in the Menu. </li>
>> <li><b>Touchpad(Press down)</b>: Select object from the Menu. At each level, spawn each 4 game object up to the number of the game level. 	Ex) Max.#Object is 3 if Level 3. </li>
>> <li><b>Trigger button & Grip button(Holdding)</b>: Destroy the object.</li>
>> <li><b>Trigger button(Holdding/Release)</b>:  Grabbing/Throwing an object.</li>
>> <li><b>Grip button(Release)</b>: Turn off the menu.  </li>

## How to play the Game
1. Select Game Objects from the menu to build your own ball navigation way to the goal gate.
2. Pick up the ball at the platform to start this game after building up your own ball thru path.
3. Send the ball thru your built path to get the goal gate.
4. Level up to the next stage.

## Level 1
![screenshot](https://github.com/himax25/RubeGoldbergGameVR-HMD-/blob/master/Level%201%20Screenshot.PNG)
* The number of given game objects: 
>> <li>Metal Plank (1 ea): Kinematic enabled. </li> 
>> <li>Trampoline (1 ea): Gravity Enabled & Kinematic enabled. </li>
>> <li>Fan (1 ea): Kinematic enabled. </li> 
>> <li>Tube Curve (1 ea): Kinematic enabled. </li> 
* The number of collecible Starts: 10 starts to get score for each level.
* The number of Gates:
>> <li> 1 pair of Teleport Gate in & out. </li>
>> <li> 1 Goal Gate. </li> 

## Level 2
![screenshot](https://github.com/himax25/RubeGoldbergGameVR-HMD-/blob/master/Level%202%20Screenshot.PNG)
* The number of given game objects: 
>> <li>Metal Plank (2 ea): Kinematic enabled. </li> 
>> <li>Trampoline (2 ea): Gravity Enabled & Kinematic enabled. </li>
>> <li>Fan (2 ea): Kinematic enabled. </li> 
>> <li>Tube Curve (2 ea): Kinematic enabled. </li> 
* The number of collecible Starts: 10 starts to get score for each level.
* The number of Gates:
>> <li> 1 pair of Teleport Gate in & out. </li>
>> <li> 1 Goal Gate. </li> 

## Level 3
![screenshot](https://github.com/himax25/RubeGoldbergGameVR-HMD-/blob/master/Level%203%20Screenshot.PNG)
* The number of given game objects: 
>> <li>Metal Plank (3 ea): Kinematic enabled. </li> 
>> <li>Trampoline (3 ea): Gravity Enabled & Kinematic enabled. </li>
>> <li>Fan (3 ea): Kinematic enabled. </li> 
>> <li>Tube Curve (3 ea): Kinematic enabled. </li> 
* The number of collecible Starts: 10 starts to get score for each level.
* The number of Gates:
>> <li> 2 pairs of Teleport Gate in & out. </li>
>> <li> 1 Goal Gate. </li> 

## Level 4
![screenshot](https://github.com/himax25/RubeGoldbergGameVR-HMD-/blob/master/Level%204%20Screenshot.PNG)
* The number of given game objects: 
>> <li>Metal Plank (4 ea): Kinematic enabled. </li> 
>> <li>Trampoline (4 ea): Gravity Enabled & Kinematic enabled. </li>
>> <li>Fan (4 ea): Kinematic enabled. </li> 
>> <li>Tube Curve (4 ea): Kinematic enabled. </li> 
* The number of collecible Starts: 10 starts to get score for each level.
* The number of Gates:
>> <li> 2 pairs of Teleport Gate in & out. </li>
>> <li> 1 Goal Gate. </li> 

## Major Features to apply in this project
This SteamVR based Rube Goldberg Game applies the following features:
* Adding on both SteamVR and Oculus SDKs at this Unity project.
* Designing 2 6DoF hands controllers for this game.
* Applying Teleport movement and walking locomotion for Left controller.
* Applying Grabbing and Throwing any object and a ball as hand action movement for a Right controller.
* Building up a Menu system for Game objects to choose.
* Attaching UI for the current Game object possession.
* Designing anti-cheating mechanism by active/in-active ball status.
* Applying Scene loading mechanism when the player achieves mission at each level.
* Building up 4 kinds of Game objects and obstacles at each stage.
* Storing and displaying game score in each level at Scoreboard UI.

## The period of developing 
It takes 100 hours to develop and test this project.

## Major Challenges in the project.
There are some chanllenges to build up a scenario for the level of difficluties. At every time I test each game scenario at each level, it is too hard to control the level of game difficulties with all give game objects with building layout due to accuracy ball movement control. 

# Conclusion

## **Author of this coding**
* Hyo Lee, linkedin [here](https://www.linkedin.com/in/hyo-max-lee-61241b13/)
* Unity 2017.2.0f3, GVR Unity SDK v1.60.0, SteamVR Build version 1527117754
* Test Platform Windows 10 Home Edition 64 Bit OS /w Oculus Rift.
* June 7, 2018.
