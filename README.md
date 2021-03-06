# Udacity High Immersion Unity with 6DoF VR: Rube Goldberg Game Project.
This is the 1st project for High Immersion Unity VR at Nanodegree program in Udacity. 
This VR game environment is based on 6DoF controllers with SteamVR Scripts to support both HTC's VIVE and Oculus' Rift HMDs.
![youtubelink](https://github.com/himax25/RubeGoldbergGameVR-HMD-/blob/master/Screenshot%20of%20Youtube.PNG)[for playing Youtube video here](https://youtu.be/S4AoDI8p_FQ)
The player needs to build up his or her own ball rolling journey to the goal gate with 4 difference game objects by the game menu. In each level, there have different layouts for both factorial structure and teleport gateways, and a limited number of game-object to choose. The winning condition of this game is how long the ball takes to get thru the goal gate and how many stars the ball takes in its ball rolling journey.

# Design and Deployment
Building up Rube Goldberg Ball rolling journey from Playing Start platform to the Goal gate by Game Object puzzled location with Teleports. The player will get essential score points thru 10 stars to collect on its ball path with execution time at each level.

## Persona: a typical user
I assume the target audience of this Rube Goldberg Puzzle Game as the followings:
* **Hilary Lee**, 12, a Girl, Middle School student.
> Hilary is very excited to try on such new device based game,  High Immersion HMD VR, to play at these days. 

## Movement Control
SteamVR based management supports multi High Immersion Head Mount Device with controlles such as VIVE HTC and Oculus Rift.
* Left Controller: control teleport and locomotion.
>> <li><b>Trigger button hold/release</b>: Teleport to TeleportAimer. </li>
>> <li><b>Grip button holdding</b>: Walking locomotion. </li>
* Right Contoller: Game Object Menu and Ball control. </li>
>> <li><b>Touchpad(Swipping L/R)</b>: Show objects in the Menu. </li>
>> <li><b>Touchpad(Press down)</b>: Select object from the Menu. At each level, spawn each game object up to the number of the game level. Ex) Max.#Object is 3 with 3 kinds of objects if Level 3. </li>
>> <li><b>Trigger button & Grip button(Holdding)</b>: Destroy the object.</li>
>> <li><b>Trigger button(Holdding/Release)</b>: Grabbing/Throwing an object.</li>
>> <li><b>Grip button(Release)</b>: Turn off the menu. </li>

## How to play the Game
1. Select Game Objects from the menu to build your own ball navigation way to the goal gate.
2. Pick up the ball at the platform to start this game after building up your own ball thru path.
3. Send the ball thru your built path to get the goal gate with collecting number of Stars.
4. Level up to the next stage if the player achieve to collect the number of Stars at each level.

## Anti-cheating algorithm
* The play ball will be only activated at the playzone platform.
* The game will be restarted if the play grabs the ball at the out of the playzone platform.
* The game will be reloaded if the player could not achieve the mission of each level to collect stars.

## Level 1
![screenshot](https://github.com/himax25/RubeGoldbergGameVR-HMD-/blob/master/Level%201%20Screenshot.PNG)
* The number of given game objects: 
>> <li> 1 pair of Teleport Gate in & out. </li>
>> <li> 1 Goal Gate. </li> 
>> <li> 1 Game object to play with: Metal Plank. </li>
>> <li> The player needs to collect at least 5 Stars during playing the game, otherwise the game will be reloaded. </li>

## Level 2
![screenshot](https://github.com/himax25/RubeGoldbergGameVR-HMD-/blob/master/Level%202%20Screenshot.PNG)
* The number of given game objects: 
>> <li> 1 pair of Teleport Gate in & out. </li>
>> <li> 1 Goal Gate. </li> 
>> <li> 2 Game objects to play with: 2 Metal Planks and 2 Fans. </li>
>> <li> The player needs to collect at least 6 Stars during playing the game, otherwise the game will be reloaded. </li>

## Level 3
![screenshot](https://github.com/himax25/RubeGoldbergGameVR-HMD-/blob/master/Level%203%20Screenshot.PNG)
* The number of given game objects: 
>> <li> 2 pairs of Teleport Gate in & out. </li>
>> <li> 1 Goal Gate. </li> 
>> <li> 3 Game objects to play with: 3 Metal Planks, 3 Fans, and 3 Tube Curve. </li>
>> <li> The player needs to collect at least 7 Stars during playing the game, otherwise the game will be reloaded. </li>

## Level 4
![screenshot](https://github.com/himax25/RubeGoldbergGameVR-HMD-/blob/master/Level%204%20Screenshot.PNG)
* The number of given game objects: 
>> <li> 2 pairs of Teleport Gate in & out. </li>
>> <li> 1 Goal Gate. </li> 
>> <li> 4 Game objects to play with: 4 Metal Planks, 4 Fans, 4 Tube Curve, and 4 Trampoline. </li>
>> <li> The player needs to collect at least 8 Stars during playing the game, otherwise the game will be reloaded. </li>

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
It takes 80 hours to develop and test this project.

# User testing with feedback and major challenges
## User testing for this Rube Goldberg Puzzle Game
I asked the 1st user to play this 6DoF VR game and get some feedback from the user after playing it.
* **Feeback:** the user told me that she got a little dizzy during playing with such 6DoF HMD's locomotion. It is too fast to move and she is familar to play such 6DoF HMD's locomotion. 
* **Enhancing:** I have recalibrated the parameter of the moving speed with locomotion to make her comfortable.

## Major challenges in this project.
There are some challenges to build up a scenario for the level of difficulties.
At every time I test each game scenario at each level, it is too hard to controll the level of difficulties with all given game objects with building layout due to maintaining the accuracy of the ball movements at each time.  

# Conclusion

## **Author of this coding**
* Hyo Lee, linkedin [here](https://www.linkedin.com/in/hyomaxlee/)
 
## Versions
- Unity 2017.2.0f3
- GVR Unity SDK v1.60.0
- SteamVR Build Vesion 1527117754.
- Test Platform: Windows 10 Home Edition 64 Bit OS /w Oculus Rift HMD

## Free Assets to download from online Store for this game. 
- Downloaded prefabs from Unity Asset Store;
>> (1) Tube constructor Kit prefabs, Environments > Urban,https://deployer117.deviantart.com/
- Download FX Sound from Unity Asset Store;
>> (1) FREE Casual Game SFX Pack from dustyroom.com, UX/UI sounds, 24-bit WAV format, 44.1 kHz Stereo.
- Download Background Music from Unity Asset Store;
>> (1) Absolutely Free Music, Vertex Studio
