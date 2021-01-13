# ResearchEcoSystem
Project for gameplay

Hello, and welcome to my research project for gameplay programming.

In this project, I'm gonna guide you through my first time making something with AI in unity.
During gameplay programming, we saw steering behaviours, behaviour tree, finite state machine, but for this project, I decided to keep it simple.
My main focus was towards creating funny behaviour and learning about how a navmesh works in Unity, and how you need to redesign certain script to make it more usable for gameobjects.

I chose to create a small ecosystem. My ecosystem is a peaceful grassland with some puddles, where rabbits try to survive by paying attention to their hunger, thirst, and of course, procreating.

I got the idea about the ecosystem by watching a video on youtube (https://www.youtube.com/watch?v=r_It_X7v-1E). 

I used some cubes and capsules to quickly create something that represents bunnies. after putting some time in a small environment, I started to looking into the navmesh, how you need to bake it, and started to look up what you can do with the navmesh.

![alt text](https://github.com/Eonaap/ResearchEcoSystem/blob/master/Bunny.png?raw=true)

After I got the bunnies to wander around, I could start adding stats. I first started with adding hunger and thirst. Then I needed to start on something that was more difficult then expected, what's the best way to represent the food and water to the bunnies?
For the food, I made a quick prefab with some green cylinders. After some trial and error, I opted for working with colliders. I let the bunnies go over all the colliders. Every bunny had a target for food, and water. I updated that target, so that when the status script showed the bunny was thirsty or hungry, it could automatically go over to what it needed. 

![alt text](https://github.com/Eonaap/ResearchEcoSystem/blob/master/WaterAndFood.png?raw=true)

For the water, it was more difficult to make it accessable for multiple bunnies. I chose to go for boxes of colliders along the waterside. so that would find the invisible colliders, and they could start drinking.

After the drinking and eating worked. I could start working on the procreating. This is shown by the horny level of the bunny. While working on this, I thought it wuold be a good experiment to see what happens if you only place one female bunny, and 4 male bunnies. This way, it would take longer for them to multiply.
I went for an approach, where the female bunnies usually take longer to reach the level of excitement to procreate, to make slightly more difficult to fill the grasslands with bunnies.

To decide what the bunny needed the most. I went with 4 main checks. 
1. Is the bunny Horny?
The most difficult thing for the bunnies to do, was procreating, cause of how long it took to get ready to do it again. It may not have been a crucial part for surviving, but that didn't make it crucial for the bunnies as a species to survive.

2.Does the bunny have a critical value that needs urgent attention?
If a stat would be under 25%, that would need to become the number one priority. so either go towards it, or wander around till they found it.

3. Is the bunny too full in either thirst or hunger?
I decided to make it, so bunnies will not start eating when their hunger bar is above 75%. Bunnies wouldn't only eat, and occasionally drink something. It also makes it, so they don't forget one of the 2.

4.If these requirements aren't met, what's the thing the bunny needs the most?
This is just a simple check if the bunny's hunger or thirst is the lowest.

If a bunny wouldn't be able to eithe keep their hunger or thirst bar filled, they would start to slowly lose health. They regain this very slowly, but I really wanted to make losing health way more impactful then regaining it. 

This was my thought process through making this AI.
To end, I want to say that this project made me interested in maybe remaking the whole thing, and getting rid of the flaws that are in the project. Next time, I think it would be interesting to test out the behaviour trees in unity, which isn't a big leap for the way I tackled this project. I wish I would've spend some more time into this project, but as a first try in making a game without any real human interaction, it surely learnt me a thing or 2.

