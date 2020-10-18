// Mean Altarboy
VAR first_altarboy_engagement = true
VAR nice_altarboy_engaged = false

==start_mean_altarboy==
Psst! Over here! #name:Chauncey
*[Who, me?]
Are you talking to me? #name:Kay
Yeah! Wanna hear something funny? #name:Chauncey
    **[Sure.]
    Sure. #name:Kay
    The priest always ties his rope without looking. #name:Chauncey
        ***[What's so funny about that?]
        What's so funny about that? #name:Kay
        Well, I found a garden snake on the grounds this morning... #name:Chauncey
        ->prank_mean_altarboy
        ***[The priest is weird...] #name:Kay
        Tell me about it! And guess what I found on the grounds this morning? #name:Chauncey
            ****[What?] #name:Kay
            A garden snake... #name:Chauncey
            ->prank_mean_altarboy
            
==prank_mean_altarboy==
{
    - nice_altarboy_engaged == false:
        *[Uh-oh...] I think I know what you're thinking... #name:Kay #mood:Kay_sad
        He-he-he! We're going to replace the rope with the snake! #name:Chauncey
            **[What do you mean, "we"?] #name:Kay
            I'll distract him, and you can swap the items! It'll be hilarious! #name:Chauncey
                ***[I'm in!] #name:Kay 
                Jolly good! #name:Chauncey
                ->yes_mean_altarboy
                ***[No thanks...]
                Goodie two shoes! Fine, I'll do it alone.  #name:Chauncey
                ->no_mean_altarboy
    
    - else: 
        ->bully_mean_altarboy
}

==yes_mean_altarboy==
I'll distract the priest, and you simply pick up his rope and move it off the altar, then leave the snake where the rope was. #name:Chauncey
    *[Won't the snake wriggle away?] #name:Kay
    Not if it knows what's good for it! #name:Chauncey
        **[You're a bit aggressive, aren't you?] #name:Kay
        I just take my fun very seriously. #name:Chauncey 
        ->END
==no_mean_altarboy==
*[Do you really think you should?] #name:Kay
The priest is so mean! This will do him good. #name:Chauncey 
/* TODO: Have the altarboy swap out the rope with snake. The priest catches him, reprimands him by saying "Are you mad, child?! Be gone! You and your family are barred from church for one week!" Wasn't sure how to format this into the script so I'm just including it here as a note*/
->END

==bully_mean_altarboy==
*[I see where this is going...] #name:Kay
Hrmph! I bet that goodie two shoes ratted on me, didn't he? #name:Chauncey
    **[No he didn't.] #name:Kay
    Well... if you say so. Well, what about it? Are you helping me or not? #name:Chauncey
        ***[I'm in!] ->yes_mean_altarboy #name:Kay #name:Kay_happy
        ***[No thanks...] ->no_mean_altarboy #name:Kay #name:Kay_sad
    **[The nice boy did warn me about you, it's true.] #name:Kay
    I knew it! He's a tattler if I ever saw one. #name:Chauncey #name

    /* TODO: The meanaltarboy rushes at the nice one, camera shakes to indicate that he hit him. The boy cries. "Wahhhh!!" and darts off screen. The priest says "That boy was weak..." And I guess that would end this branch of the miniquest.*/
    ->END
    
    
    
    
    
    
    