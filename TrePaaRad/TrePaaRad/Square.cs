namespace TrePaaRad;

internal class Square
{
    private int _content;

    public bool IsEmpty()
    {
        return _content == 0;
    }


    public bool IsPlayer1()
    {
        return _content == 1;
    }

    public void Mark(bool isPlayer1)
    {
        if (!IsEmpty()) return;
        _content = isPlayer1 ? 1 : 2;
    }

    public int GetContentValue()
    {
        return _content;
    }

    public void SetContentValue(int value)
    {
        _content = value;
    }

}