using UnityEngine;

public class IdleState: IState
{
    private Character _character;
    private CharacterVision _vision;
    
    public IdleState(Character character)
    {
        _character = character;
    }

    public void SetNewState()
    {
        _character.SetNewState(new IdleState(_character));
    }

    public void UpdateState()
    {
        if (_vision.TryGetTarget(out GameObject target) == false)
        {
            
        }
        
        // TODO Дописать внутреннее состояние
    }
}