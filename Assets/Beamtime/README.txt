----Beamtime README----

Hello and thankyou for purchasing Beamtime!

Beamtime is a pair of scripts aimed at creating interactive and realistic laser beams within Unity 4.5+. 

Each laser object is indentified by the laser script then it’s processed by the laser system script in order to aid performance. 

Beamtime is also a term in particle physics. It’s shorthand for the time allocated to a researcher to
research particle beams from a particular source
We named our asset Beamtime after it was suggested to us by arcosapphire on reddit. We liked
the term and it’s meaning so it stuck!
With this asset, you can have your own beams to research.
Enjoy your Beamtime!

If you have any issues or improvements for us, please let us know via our websites contact page - http://eageramoeba.co.uk/Contact/

Package Contains 
-Sample effects 
-Sample laser shader and texture 
-Laser script 
-Laser System script 
-Billboard script 
-DestroyFX script 
-Prefabs 
	-FX objects 
	-Laser object 
	-Laser system
-This README file

Quickstart:
1. Place the LaserSystem prefab into your scene, this is used to manage the system.
2. Place the Laser prefab into your scene at the position you want a lazer.
3. Play and enjoy!

Uses:
It could be used for weapons, a death star effect, a puzzle themed around the reflection and intersection of laser beams. Basically anything you can think of involving laser beams!

Limitations:
The product is limited by the complexity of your simulation, as the calculations are quite complex you need to take care to not overload the system with too many objects (we’ve tested this system with 20+ lasers and errors/performance hits show when these lasers all collide with each other, if this can be mitigated we recommend you doing so). 
The effects we’ve provided are incredibly basic, while these are usable we recommend creating your own shaders for emission and global illumination. These can be found on the asset store for next to nothing so this shouldn’t be an issue. 
With regards to multiplayer, due to the systems involved for network communication being complex and specialised, we have only tested this locally. We recommend test and integrating this asset carefully into your own networking/multiplay solution. There’s information on how we would recommend doing this is the multiplayer section.

Version differences:
We have made the asset compatible with Unity 4.5+ 
All versions are almost identical bar the effects provided. 
In Unity 4, the effects are far more basic than those found in 5 due to the integration of the advanced particle system.