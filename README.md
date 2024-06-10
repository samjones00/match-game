# Match Game

I've implemented the solution as a console application, prompting the user for both the number of decks and the match condition on running the application.

### If i spent more time
* Implement a better random generator, possibly the fisher yates or cryptographic algorithm.
* Maybe move the TakeCard method to the deck factory and make it non static, to more easily mock the deat cards.
* Maybe add a Player object with a factory method, but as it was used in only one class I thought it unnessary.