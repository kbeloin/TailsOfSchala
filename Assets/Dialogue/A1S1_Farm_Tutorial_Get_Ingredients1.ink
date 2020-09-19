VAR first_engagement = true

{ first_engagement == false:
    Did you get the ingredients? # Mother
    *[Not yet.] #Kay # Kay_sad
    Well, back outside with you! # Mother # Mother_sad
    ->DONE
    - else:
    ->task

}

==task==
~ first_engagement = false
Good morning sleepyhead. # Father # Father_happy
*[Good morning everyone!] # Kay # Kay_happy
Annnnddd...? # Thomas 
    **[And happy birthday, Thomas.]# Kay
    Thank you.# Thomas #Thomas_happy
    Birthday breakfast is just getting started, but I need a few more ingredients.
    Kay, could you fetch me: one *fresh mushroom*, one *rosemary sprig*, and one *saffron flower*? They should be lying about somewhere on the farm.# Mother
    ->END
    **[Umm... and?]# Kay
    It's my birthday!# Thomas #Thomas_happy
    You didn't forget, did you?# Mother # Mother_sad
        ***[Of course not! I'm only teasing.]# Kay #Kay_happy
        Birthday breakfast is just getting started, but I need a few more ingredients. Kay, could you fetch me: one *fresh mushroom*, one *rosemary sprig*, and one *saffron flower*? They should be lying about somewhere on the farm.# Mother 
        ->END
        ***[But children brought by the stork don't have birthdays. That's the law.]# Kay
        Never heard of that law before.# Thomas #Thomas_sad
        The law's the law, Thomas. No birthday for you.# Father
        They're only being silly, Thomas. Kay, your brother's birthday breakfast is just getting started, but I need a few more ingredients. 
        
        Kay, could you fetch me: one *fresh mushroom*, one *rosemary sprig*, and one *saffron flower*? They should be lying about somewhere on the farm.# Mother
            ->END
*[...yawnnnn...]# Kay
Did you not sleep well last night, Kay?# Mother
    **[I was reading until pretty late.]# Kay
    You know you have a midnight curfew on reading. It makes you groggy.# Mother
        ***[Oh okay...]# Kay #Kay_sad
        Kay, your brother's birthday breakfast is just getting started, but I need a few more ingredients. Kay, could you fetch me: one *fresh mushroom*, one *rosemary sprig*, and one *saffron flower*? They should be lying about somewhere on the farm.# Mother
        ->END
        ***[But I'm on the track of an interesting point on electrodynamics.]# Kay #Kay_sad
        Nerd!# Thomas #Thomas_happy
        That sounds interesting, Kay, but please respect the curfew tonight.# Mother
            ****[I will.]# Kay
            Your brother's birthday breakfast is just getting started, but I need a few more ingredients. Kay, could you fetch me: one *fresh mushroom*, one *rosemary sprig*, and one *saffron flower*? They should be lying about somewhere on the farm.# Mother
            ->END
    **[...no, I slept okay. Just need a bit of sunlight.]# Kay
    Hmm... alright.# Mother
    Hey sister. Know what today is?# Thomas
        ***[Of course! It's your birthday.]# Kay #Kay_happy
        You remembered!# Thomas #Thomas_happy
            ****[You bet I did!]# Kay #Kay_happy
            Kay, your brother's birthday breakfast is just getting started, but I need a few more ingredients.Kay, could you fetch me: one *fresh mushroom*, one *rosemary sprig*, and one *saffron flower*? They should be lying about somewhere on the farm.# Mother
        
            ->END
            ****[Just barely, too!]# Kay #Kay_happy
            Kay, your brother's birthday breakfast is just getting started, but I need a few more ingredients. Could you fetch me: one *fresh mushroom*, one *rosemary sprig*, and one *saffron flower*? They should be lying about somewhere on the farm.# Mother
            ->END
        ***[Sunday.]# Kay
        ...Sunday? Just plain old Sunday?# Thomas #Thomas_sad
        Kay, it's your brother's birthday today.# Mother
            ****[I know! I'm only teasing.]# Kay #Kay_happy
            Thomas's birthday breakfast is just getting started, but I need a few more ingredients. Kay, could you fetch me: one *fresh mushroom*, one *rosemary sprig*, and one *saffron flower*? They should be lying about somewhere on the farm.# Mother
            ->END
            ****[Are you sure?]# Kay
            Don't be silly. Here, I have something for you to do. Your brother's birthday breakfast is getting underway, but I need a few more ingredients. Could you fetch me: one *fresh mushroom*, one *rosemary sprig*, and one *saffron flower*? They should be lying about somewhere on the farm.# Mother
            ->END
