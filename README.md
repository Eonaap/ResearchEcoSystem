# ResearchEcoSystem
The main focus was towards creating funny behaviour and learning about how a navmesh works in Unity, and how you need to redesign certain script to make it more usable for gameobjects.

In this project, you see the cration of a small ecosystem. The ecosystem is a peaceful grassland with some puddles, where rabbits try to survive by paying attention to their hunger, thirst, and of course, procreating.

The idea about the ecosystem came from a video on youtube (https://www.youtube.com/watch?v=r_It_X7v-1E). 

## What is an ecosystem?
According to National Geographics: "An ecosystem is a geographic area where plants, animals, and other organisms, as well as weather and landscapes, work together to form a bubble of life."

So the goal of the project is to create an area, where animals and plants work together to survive. In this case, I chose bunnies that survive by eating plants, drinking water, and procreating.

## The start of the project

The bunnies were made out of some boxes and capsules to go faster to the important stuff. after putting some time in a small environment, I started to look into the navmesh, how you need to bake it, and started to look up what you can do with the navmesh.

![alt text](https://github.com/Eonaap/ResearchEcoSystem/blob/master/Bunny.png?raw=true)

After the bunnies started to wander, statistics were added. It started with adding hunger and thirst. Then the question came, what's the best way to represent the food and water to the bunnies?
For the food, quick prefab with some green cylinders got created. After some trial and error, going with colliders was the best way to get the bunnies to see the plants easily. The bunnies go over all the colliders in range every update. Every bunny has a target for food, and water. Together with the stats script, a bunny can decide if it's hungry or thirsty, and go towards the closest one. 

![alt text](https://github.com/Eonaap/ResearchEcoSystem/blob/master/WaterAndFood.png?raw=true)

For the water, it was more difficult to make it accessable for multiple bunnies. The way that was found was adding collider boxes, that the bunnies can find the same way they did with the grass.

After the drinking and eating worked came the procreating. This is shown by the horny level of the bunny. The level starts with only one female bunny, and 4 male bunnies.
This way, it would take longer for them to multiply.
The female bunnies usually take longer to reach the level of excitement to procreate, to make it slightly more difficult to fill the grasslands with bunnies.
                                                                                                                                                        
To decide what the bunny needed the most. I went with 4 main checks.    
1. Is the bunny Horny?
The most difficult thing for the bunnies to do, was procreating, cause of how long it took to get ready to do it again. 
It may not have been a crucial part for surviving, but that didn't make it crucial for the bunnies as a species to survive.

2.Does the bunny have a critical value that needs urgent attention?
If a stat would be under 25%, that would need to become the number one priority. so either go towards it, 
or wander around till they found it.

3. Is the bunny too full in either thirst or hunger?
I decided to make it, so bunnies will not start eating when their hunger bar is above 75%. Bunnies wouldn't only eat, 
and occasionally drink something. It also makes it, so they don't forget one of the 2.                                                                                                                          
4.If these requirements aren't met, what's the thing the bunny needs the most?
This is just a simple check if the bunny's hunger or thirst is the lowest.  

![alt text](https://github.com/Eonaap/ResearchEcoSystem/blob/master/Decision.png?raw=true)

If a bunny wouldn't be able to eithe keep their hunger or thirst bar filled, they would start to slowly lose health. They regain this very slowly, but I really wanted to make losing health way more impactful then regaining it. 

## To summarize
The project has missing some of the key features, but even with the small amount of features, it was a good way of learning the basics of how to work with AI in Unity.

### Links
[What is an ecosystem](https://www.nationalgeographic.org/encyclopedia/ecosystem/)
[What do wild bunnies do](https://www.peta.org/issues/wildlife/rabbits/#:~:text=During%20warmer%20seasons%2C%20rabbits%20will,for%20their%20ability%20to%20reproduce.)

