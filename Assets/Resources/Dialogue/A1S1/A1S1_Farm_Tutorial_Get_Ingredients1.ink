// Birthday Breakfast
VAR first_birthday_breakfast_engagement = true

==start_birthday_breakfast_father==
{ 
    - first_birthday_breakfast_engagement:
        -> task_birthday_breakfast
    - thomas_birthday_breakfast_complete:
        -> start_goat_chores
    - else:
        I think I saw some mushrooms growing in the glade, southwest of the house. #name:Father
        -> END
}

==start_birthday_breakfast_brother==
{ 
    - first_birthday_breakfast_engagement:
        Father wants to talk to you. Are you in trouble? #name:Thomas #mood:happy
        -> END
    - thomas_birthday_breakfast_complete:
        I can't wait to eat! #name:Thomas #mood:happy
        -> END
    - else:
        Check for herbs by the river. #name:Thomas #mood:happy
        -> END
}

==start_birthday_breakfast_mother==
{ 
    - first_birthday_breakfast_engagement:
        Good morning, sweetheart!  #name:Mother #mood:happy
        -> END
    - thomas_birthday_breakfast_complete:
        -> start_goat_chores
    - else:
        -> reminder_birthday_breakfast
}

==reminder_birthday_breakfast==
Did you get the ingredients? #name:Mother
+Not yet. #name:Kay #mood:sad
    Well, back outside with you! #name:Mother #mood:sad
    ->END
* { thomas_birthday_breakfast_ready } [Here you go, Mother.]
    Five mushrooms, five herbs, and five flowers. #name:Kay #mood:happy
    Thank you, Kay. Mmm, it smells so delicious! #name:Mother #mood:happy 
    ~ tooltip = "You give Mother the ingredients."
    -> complete_birthday_breakfast

==task_birthday_breakfast==
~ first_birthday_breakfast_engagement = false
Good morning, sleepyhead. #name:Father #mood:happy
*[Good morning!]
Good morning everyone! #name:Kay #mood:happy
Annnnddd...? #name:Thomas #mood:mad
    **[Happy birthday!]
    And happy birthday, Thomas. #name:Kay #mood:happy
    Thank you.#name:Thomas #mood:happy
    Birthday breakfast is just getting started, but I need a few more ingredients. #name:Mother 
    ->finish_birthday_breakfast_with_name
    **[Umm...]
    Umm... and? #name:Kay 
    It's my birthday!#name:Thomas #mood:happy
    You didn't forget, did you?#name:Mother #mood:sad
        ***[Of course not!]
        Of course not! I'm only teasing.#name:Kay #mood:happy
        Birthday breakfast is just getting started, but I need a few more ingredients. #name:Mother 
        ->finish_birthday_breakfast_with_name
        ***[Hmm...]
        But children brought by the stork don't have birthdays. That's the law. #name:Kay 
        Never heard of that law before.#name:Thomas #mood:sad
        The law's the law, Thomas. No birthday for you. #name:Father #mood:sad
        They're only being silly, Thomas. #name:Mother #mood:happy
        Kay, your brother's birthday breakfast is just getting started, but I need a few more ingredients. #name:Mother 
        ->finish_birthday_breakfast
*[...yawnnnn...]
....  #name:Kay #mood:sad
Did you not sleep well last night, Kay? #name:Mother #mood:sad
    **[Well...]
    I was reading until pretty late. #name:Kay #mood:sad
    You know you have a midnight curfew on reading. It makes you groggy.#name:Mother #mood:sad
        ***[Okay.]
        Oh okay...#name:Kay #mood:sad
        Birthday breakfast is just getting started, but I need a few more ingredients. #name:Mother 
        ->finish_birthday_breakfast_with_name
        ***[But...]
        But I'm on the track of an interesting point on electrodynamics.#name:Kay #mood:sad
        Nerd!#name:Thomas #mood:happy
        That sounds interesting, Kay, but please respect the curfew tonight.#name:Mother #mood:sad
        I will. #name:Kay 
        Your brother's birthday breakfast is just getting started, but I need a few more ingredients. #name:Mother 
            ->finish_birthday_breakfast_with_name
    **[I slept okay.]
    ...no, I slept okay. Just need a bit of sunlight. #name:Kay #mood:happy
    Hmm... alright. #name:Mother #mood:sad
    Hey sister. Know what today is? #name:Thomas #mood:happy
        ***[Of course!]
        Of course! It's your birthday. #name:Kay #mood:happy
        You remembered!#name:Thomas #mood:happy
            ****[Yes!]
            You bet I did!#name:Kay #mood:happy
            Kay, your brother's birthday breakfast is just getting started, but I need a few more ingredients. #name:Mother 
            ->finish_birthday_breakfast
            ->END
            ****[Yep.]
            Just barely, too! #name:Kay #mood:happy
            Kay, your brother's birthday breakfast is just getting started, but I need a few more ingredients. #name:Mother 
            ->finish_birthday_breakfast
            ->END
        ***[Sunday.]
        Sunday. #name:Kay 
        ...Sunday? Just plain old Sunday?#name:Thomas #mood:sad
        Kay, it's your brother's birthday today.#name:Mother #mood:sad
            ****[I know!]
            I know! I'm only teasing.#name:Kay #mood:happy
            Thomas's birthday breakfast is just getting started, but I need a few more ingredients. #name:Mother 
            ->finish_birthday_breakfast_with_name
            ->END
            ****[Hmm...]
            Are you sure? #name:Kay #mood:sad
            Don't be silly. Here, I have something for you to do. #name:Mother #mood:sad
            Your brother's birthday breakfast is getting underway, but I need a few more ingredients. #name:Mother 
            ->finish_birthday_breakfast
            ->END
    
==finish_birthday_breakfast==
Could you fetch me: five <b>fresh mushrooms</b>, five <b>rosemary sprigs</b>, and five <b>saffron flowers</b>?#name:Mother #mood:happy #quest:ThomasBirthdayBreakfast
~ tooltip = "Tap L to view your quest log"
They should be lying about somewhere on the farm. #name:Mother #mood:happy
->END

==finish_birthday_breakfast_with_name==
Kay, could you fetch me: five <b>fresh mushrooms</b>, five <b>rosemary sprigs</b>, and five <b>saffron flowers</b>?#name:Mother #mood:happy #quest:ThomasBirthdayBreakfast 
~ tooltip = "Tap L to view your quest log"
They should be lying about somewhere on the farm. #name:Mother #mood:happy
->END

==complete_birthday_breakfast==
~ thomas_birthday_breakfast_complete = true
Well done, Kay! This will make a fine meal.#name:Mother #mood:happy
A young lady ought to know a few recipes. Why don't you try making these <b>Herb-Roasted Mushrooms</b>? #name:Mother
~ tooltip = "Received an item!"
Give it a try on our <b>stove</b>. #name:Mother
I'm hungry! #name:Thomas #mood:sad
We know! #name:Father #mood:sad
TODO: Fade to black while they eat 
->END