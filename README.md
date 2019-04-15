# Toss N' Wash

[Link To Free Game!](https://therealdrew.itch.io/toss-n-wash)

## Things
This is game was made by [Jessie](https://github.com/JurassicJessie "3D Modeler") 
and I, where Jessie is the novice 3D Modeler, and I was/is/something the programmer.
I used the game engine Unity version 2017.4.18f1. The code is in C#.
I've decided to put all of the code and stuff on here, so someone who is learning to build a game from scratch, you can see how I approached it. Keep in mind, this was done in 2 days. I tried to stick to [SOLID](https://youtu.be/eIf3-aDTOOA) and best practices as much as I could. But I think I went off those rails early on.

## About
This was made during the  [Extra Credits Game Jam #3](https://itch.io/jam/extra-credits-game-jam-3 "FR33 GAM3").
Sadly, it was finished about ~30 minutes after the deadline, so it was never submitted.
The theme is cycles and a washing machine was the first to come to mind. So I went with that. Want some lore? Well, this takes place across the Golden Gate bridge, where some random rich person, who owns pretty much all of that land of Sausalito, needs to put random items in his laundry machine. He loves numbers, especially prime numbers, so he gets a score for putting in random items in his washing machine.

## Instructions
You hold key 'z' down to initially get an item, and then to throw the item, you fling your mouse in some random direction (preferably to the direction of the washing machine) and let go of key 'z' to release the item. You can click and hold the left mouse button instead of holding key 'z', but it was found easier to fling the mouse and hit a key on the keyboard than using the mouse and click-hold according to the Toss N' Wash Game Design Of Absolute Greatness Consensus Bureau To The Max, otherwise famously known as [TNWGDOAGCBTTM](https://www.youtube.com/watch?v=g9ixvD0_CmM "TNETENNBA").


## Assets used
I use Unity Camera Asset, CCTV, to follow the mouse movement smoothly. For level transitions between scenes, I used the tutorial [Makin' Stuff Look Good](https://www.youtube.com/watch?v=LnAoD7hgDxw). You can check out how I connected it into the game in the [TransitionsManager](https://github.com/TheDrw/WashingMachineGameJam/tree/master/WashingMachineGameJam/Assets/Camera). I used a free skybox asset from [Boxophobic](https://assetstore.unity.com/publishers/20529). The font is [BradBunR](https://github.com/TheDrw/WashingMachineGameJam/tree/master/WashingMachineGameJam/Assets/Core/Font). And that's all I think at the moment.

## Unity Concepts I implement That Might Be Useful For The Novice
* **Folder organization**. I think this is the most over looked concept. For the most part, I like having my files separated by their general abstract representation in the game. You can take a [look](/WashingMachineGameJam/Assets/) to get a general sense of what I mean. I follow it for the most part. I see people making files like scripts, prefabs, etc, but personally, I don't like that because there's already a [search by type](https://docs.unity3d.com/Manual/ProjectView.html) function in the project window that does that for you. It also follows my namespace convention, so I know what dependencies I am importing when coding.

* **Presistent Game Objects**. There are objects I don't [destroy on load](https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html), and they are loaded in the \_PRELOAD scene and live throughout the game once started. They are the [LevelSelectorManager](/WashingMachineGameJam/Assets/Core/LevelSelect/), 
[SoundManager](/WashingMachineGameJam/Assets/Core/Sound/), 
and [MusicManager](/WashingMachineGameJam/Assets/Core/Music). They are singletons that can be accessed through the lifespan of the game. I used singletons because it was easiest to do within 2 days of making. While this small scale game doesn't really need it, if you think of a multi-scene game, this is how I would do it. At least, for mobile, this is how I do it. This is also okay if you're working on a small game, but in a bigger project, you might need to find another way of doing it. You also probably wouldn't want to have game objects in your scene that isn't really doing "game" things, like my level selector. 

* **Object Pooling**. You would generally want to use object pooling if you have a collection of items you want to reuse. In my case, I have an [ItemPool](/WashingMachineGameJam/Assets/Interactables/ItemsPool.cs) that pools in the game object from the scriptable object [ItemConfig](/WashingMachineGameJam/Assets/Interactables/ItemConfig.cs). You could put prefabs in the pooling system instead, but I'll note about it later when I mention scriptable objects. For the pooling system, I use a queue. I just went with a queue because well, why not ¯\\_(ツ)_/¯!? I've seen tutorials that utilize a list, but a queue is [_lighter_](https://stackoverflow.com/questions/10380692/queuet-vs-listt) for my implementation. The only downside for my game is that if I have 10 cups in the pool, it will show 10 cups. And when it is going back to the beginning of the queue, it will show those 10 cups in a row.

* **Scriptable Objects**. If you don't know much about scriptable objects, [link](https://youtu.be/VBA1QCoEAX4).
Each item has [ItemConfig](/WashingMachineGameJam/Assets/Interactables/ItemConfig.cs). The configuration has fields like the item prefab, points for that item, unique sound bytes (I ended up just using the same sound byte for all), etc. You can directly impact the item using scriptable objects. If you have designers on your team, they can tweak the values of the item without knowing the prefab itself. While if you are working solo, it wouldn't be a big deal if you can just put things directly on the prefab. But thinking in the long term, if you decide to expand your team, someone might apply an update on some prefab's field that is then making your game act funny in ways I can but can't imagine and you don't know why, scriptable objects will save you headaches from that. You can also adjust the config during runtime and it will save that value. That could be a both good or bad thing. Just keep that in mind. You can also build cool [architectures](https://youtu.be/raQ3iHhE_Kk) with scriptable objects. 

* **Action Events**. These are great. I use them a lot in UI such as the [Timer](/WashingMachineGameJam/Assets/UI/Timer.cs) and the [Countdown](/WashingMachineGameJam/Assets/UI/Countdown.cs). If you don't know much about them, [this guy is great](https://youtu.be/Jrwr6Yk_044). This is also known as the [observer pattern](https://youtu.be/Yy7Dt2usGy0).

## Bugs
* When throwing the object, it is possible the item doesn't register the amount of "throw" needed. I didn't really test this extensively, but it works as a standalone 8/10 on my friends computers and in the editor on my computer 9/10. My guess it is a input by frame issue, or something about my pr0 gam3r mouse's input rate.

* There are probably exponentially more bugs, but I ain't got time fo' dat. 

## Notes
* This was made in 2 days, so I made a lot of weird decisions on things.

* The [ThrowController](/WashingMachineGameJam/Assets/Core/Controller/ThrowController.cs) is okay. I think I could use a scriptable object called controller or abstract it. Then I could have something like KeyboardMouseInput, GameInput, or MobileInput where the controller reads from one of those input. So then if I were to extend it beyond the mouse and keyboard, I could do it "_easily_". At the moment, the ThrowController is hard stuck on only keyboard and mouse, which is fine if you want that only. I actually was initially gonna gamepad and extend it to mobile, but I got stuck on stupid things, so I made stupid decisions. 

* Saving score. I used the fast and easy PlayerPrefs. I think it's good for small and unimportant stuff or early prototypes, but I would advise not to use it for your real game if you're saving crucial data. I'd suggest using something that will save and encrypt your data in some way at the least. You can [read this from unity](https://unity3d.com/learn/tutorials/topics/scripting/introduction-saving-and-loading). Or if you're like me and don't know how to read, [this video works](https://youtu.be/eUSpGUeqYn8).

## License Stuff
[MIT LICENSE](/LICENSE). You can do whatever you want with this. You can sell it for a million bitcoins and not give me a single dogecoin. Just remember...[REMEMBER ME](https://youtu.be/AYURxfaTdpY "Bender - Remember Me").

