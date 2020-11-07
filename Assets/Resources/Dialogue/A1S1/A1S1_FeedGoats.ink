==start_goat_chores==
Are you nice and full now, Thomas? #name:Father #mood:happy
What's for lunch? #name:Thomas #mood:happy
Kay, now that you've eaten will you please see to your chores? #name:Mother
*[Chores?]
    What do I have to do this morning? #name:Kay
    Harvest some wheat, fill the goats' trough, collect a few apples, ... If you forget, check your journal. #name:Mother
    **[I'm on it.]
        I'm on it! #name:Kay #mood:happy #quest:GoatChores
    ->END
    **[But Mother, that's a lot to do.]
    I was hoping to read some more of my electronics textbook... #name:Kay #mood:sad
    You can read to your heart's content after you do your chores. Hop to it! #name:Mother #mood:sad #quest:GoatChores
    ->END