VAR wheatbattle_engaged = true

==start==

*I wish I were upstairs working on my lamp! But instead I have to reap all this wheat. This time of year is so full of chores. # Kay_sad
Nothing adventurous or imaginative about this. Wait a minute... whoa! Okay, wheat. It's on! # Kay
->DONE

==thomas==
Hey, whatcha doing? # Thomas # Enter_Thomas
*[My chores.] # Kay 
They don't look like chores! Can I help? # Thomas
    ** [No.] # Kay 
    Aw, please? # Thomas
        ***[Well... okay.] # Kay 
        /*Kay teachs Thomas how to do turn based battle. Not sure what to write for this yet.*/
        That was so much fun! Let's play again! # Thomas # Thomas_happy
            ****[Sorry, Thomas. I have to feed the goats now or Mom's going to be mad. Want to help?] # Kay 
            Sure. # Thomas # Thomasanimation
            /*finish goat feeding tutorial*/
->END