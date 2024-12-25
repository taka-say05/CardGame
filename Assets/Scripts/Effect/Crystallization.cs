using UnityEngine;

public class Crystallization : Effect
{
    public override void Trigger()
    {
        Debug.Log("Crystallization");
        //Ž‘Œ¹‚ÌŠT”O‚ª–¢’è‚Ì‚½‚ßŒã‚Å
        stack -= 2;
        Debug.Log(this + "StackCount:" + stack);
    }
}
