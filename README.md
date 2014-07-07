ride
====

A programmatic analysis of the Ride The Bus card game targetted at the .NET framework 4.0.

http://en.wikipedia.org/wiki/Ride_the_bus 

This has simplified rules in comparison to some versions of the game which exist. In this version, a diamond of cards is laid out facedown in the order 1-2-3-2-1.
          _
      _  |_|  _
 _   |_|  _  |_|   _
|_|   _  |_|  _   |_|
     |_|     |_|
     
The participant is then to proceed from the leftmost stack to the rightmost stack: picking one card at a time from one pile in each stack.

If the participant draws a picture card at any point, then they are to take a drink for as many seconds as stacks they have proceeded to.

The drawn cards are then replaced with facedown cards from the remaining cards in the deck.

The end goal is successfully get off the bus by reaching the rightmost stack without selecting a picture card in one go. Good luck!

The reason this was initially written was to calculate the average drunkeness obtained while playing this game :)
