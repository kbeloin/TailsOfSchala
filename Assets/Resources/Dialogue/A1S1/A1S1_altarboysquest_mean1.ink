==start_mean_altarboy==
Psst! Over here! # Meanaltarboy
*[Who, me?] Are you talking to me? # Kay
Yeah! Wanna hear something funny? # Meanaltarboy
    ** [Sure.] 
    Sure. # Kay
    The priest always ties his rope without looking. # Meanaltarboy
        *** [What's so funny about that?] 
        What's so funny about that? # Kay
        Well, I found a garden snake on the grounds this morning... # Meanaltarboy
        ->prank_mean_altarboy
        *** [The priest is weird...] # Kay
        Tell me about it! And guess what I found on the grounds this morning? # Meanaltarboy
            **** [What?] # Kay
            A garden snake... # Meanaltarboy
            ->prank_mean_altarboy
            
==prank_mean_altarboy==
{
    - nice_altarboy_engaged == false:
        *[Uh-oh...] I think I know what you're thinking... # Kay # Kay_sad
        He-he-he! We're going to replace the rope with the snake! # Meanaltarboy
            **[What do you mean, "we"?] # Kay
            I'll distract him, and you can swap the items! It'll be hilarious! # Meanaltarboy
                ***[I'm in!] # Kay 
                Jolly good! ->yes_mean_altarboy# Meanaltarboy
                ***[No thanks...]
                Goodie two shoes! Fine, I'll do it alone. ->no_mean_altarboy # Meanaltarboy
    
    - else: 
        ->bully_mean_altarboy
}

==yes_mean_altarboy==
I'll distract the priest, and you simply pick up his rope and move it off the altar, then leave the snake where the rope was. # Meanaltarboy
    *[Won't the snake wriggle away?] # Kay
    Not if it knows what's good for it! # Meanaltarboy
        **[You're a bit aggressive, aren't you?] # Kay
        I just take my fun very seriously. # Meanaltarboy # Meanaltarboy_distracts_priest
        ->END
==no_mean_altarboy==
*[Do you really think you should?] # Kay
The priest is so mean! This will do him good. # Meanaltarboy # Meanaltarboy_swapsoutropewithsnake
/* Have the altarboy swap out the rope with snake. The priest catches him, reprimands him by saying "Are you mad, child?! Be gone! You and your family are barred from church for one week!" Wasn't sure how to format this into the script so I'm just including it here as a note*/
->END

==bully_mean_altarboy==
*[I see where this is going...] # Kay
Hrmph! I bet that goodie two shoes ratted on me, didn't he? # Meanaltarboy
    **[No he didn't.] # Kay
    Well... if you say so. Well, what about it? Are you helpign me or not? # Meanaltarboy
        ***[I'm in!] ->yes_mean_altarboy # Kay # Kay_happy
        ***[No thanks...] ->no_mean_altarboy #Kay # Kay_sad
    **[The nice boy did warn me about you, it's true.] #Kay
    I knew it! He's a tattler if I ever saw one. # Meanaltarboy # Meanaltarboy_attacksnicealtarboy
    /* The meanaltarboy rushes at the nice one, camera shakes to indicate that he hit him. The boy cries. "Wahhhh!!" and darts off screen. The priest says "That boy was weak..." And I guess that would end this branch of the miniquest.*/
    ->END
    
    
    
    
    
    
    