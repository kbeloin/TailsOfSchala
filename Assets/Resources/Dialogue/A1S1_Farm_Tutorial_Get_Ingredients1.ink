VAR tooltip = ""
VAR first_engagement = 1

->start

==start==
{ first_engagement == 0:
    -> reminder
- else:
    -> task
}

==reminder==
Did you get the ingredients? # Mother
+Not yet. #Kay # Kay_sad
Well, back outside with you! # Mother # Mother_sad
->END

==task==
~ first_engagement = 0
Good morning sleepyhead. #Father #Father_happy
*[Good morning!]
Good morning everyone! #Kay #Kay_happy
Annnnddd...? # Thomas # Thomas_mad
    **[Happy birthday!]
    And happy birthday, Thomas. #Kay #Kay_happy
    Thank you.# Thomas #Thomas_happy
    Birthday breakfast is just getting started, but I need a few more ingredients. # Mother # Mother_neutral
    ->finish_with_name
    **[Umm...]
    Umm... and? # Kay # Kay_neutral
    It's my birthday!# Thomas #Thomas_happy
    You didn't forget, did you?# Mother # Mother_sad
        ***[Of course not!]
        Of course not! I'm only teasing.# Kay #Kay_happy
        Birthday breakfast is just getting started, but I need a few more ingredients. # Mother # Mother_neutral
        ->finish_with_name
        ***[Hmm...]
        But children brought by the stork don't have birthdays. That's the law. # Kay #Kay_neutral
        Never heard of that law before.#Thomas #Thomas_sad
        The law's the law, Thomas. No birthday for you. #Father #Father_sad
        They're only being silly, Thomas. #Mother #Mother_happy
        Kay, your brother's birthday breakfast is just getting started, but I need a few more ingredients. #Mother #Mother_neutral
        ->finish
*[...yawnnnn...]
....  # Kay # Kay_sad
Did you not sleep well last night, Kay? # Mother #Mother_sad
    **[Well...]
    I was reading until pretty late. # Kay #Kay_sad
    You know you have a midnight curfew on reading. It makes you groggy.# Mother #mother_sad
        ***[Okay.]
        Oh okay...# Kay #Kay_sad
        Birthday breakfast is just getting started, but I need a few more ingredients. # Mother # Mother_neutral
        ->finish_with_name
        ***[But...]
        But I'm on the track of an interesting point on electrodynamics.# Kay #Kay_sad
        Nerd!# Thomas #Thomas_happy
        That sounds interesting, Kay, but please respect the curfew tonight.# Mother #Mother_sad
        I will. # Kay #Kay_neutral
        Your brother's birthday breakfast is just getting started, but I need a few more ingredients. #Mother #Mother_neutral
            ->finish_with_name
    **[I slept okay.]
    ...no, I slept okay. Just need a bit of sunlight. #Kay #Kay_happy
    Hmm... alright. #Mother #Mother_sad
    Hey sister. Know what today is? #Thomas #Thomas_happy
        ***[Of course!]
        Of course! It's your birthday. # Kay #Kay_happy
        You remembered!# Thomas #Thomas_happy
            ****[Yes!]
            You bet I did!# Kay #Kay_happy
            Kay, your brother's birthday breakfast is just getting started, but I need a few more ingredients. #Mother #Mother_neutral
            ->finish
            ->END
            ****[Yep.]
            Just barely, too! # Kay #Kay_happy
            Kay, your brother's birthday breakfast is just getting started, but I need a few more ingredients. #Mother #Mother_neutral
            ->finish
            ->END
        ***[Sunday.]
        Sunday. # Kay #Kay_neutral
        ...Sunday? Just plain old Sunday?# Thomas #Thomas_sad
        Kay, it's your brother's birthday today.# Mother #Mother_sad
            ****[I know!]
            I know! I'm only teasing.# Kay #Kay_happy
            Thomas's birthday breakfast is just getting started, but I need a few more ingredients. #Mother #Mother_neutral
            ->finish_with_name
            ->END
            ****[Hmm...]
            Are you sure? # Kay #Kay_sad
            Don't be silly. Here, I have something for you to do. #Mother #Mother_sad
            Your brother's birthday breakfast is getting underway, but I need a few more ingredients. #Mother #Mother_neutral
            ->finish
            ->END
    
==finish==
Could you fetch me: one <b>fresh mushroom</b>, one <b>rosemary sprig</b>, and one <b>saffron flower</b>?# Mother # Mother_happy 
~ tooltip = "Tap Q to view your quest log"
They should be lying about somewhere on the farm. # Mother # Mother_happy
->END

==finish_with_name==
Kay, could you fetch me: one <b>fresh mushroom</b>, one <b>rosemary sprig</b>, and one <b>saffron flower</b>?# Mother # Mother_happy 
~ tooltip = "Tap Q to view your quest log"
They should be lying about somewhere on the farm. # Mother # Mother_happy
->END
