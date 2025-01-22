using UnityEngine;

public class Crystalize : Effect
{
    public override void Trigger()
    {
        //Ž‘Œ¹‚ÌŠT”O‚ª–¢’è‚Ì‚½‚ßŒã‚Å
        DecrementStack(2);
    }
}
