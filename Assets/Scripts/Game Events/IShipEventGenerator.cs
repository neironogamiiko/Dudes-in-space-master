using System;
using Game_Events.Events;

namespace Game_Events
{
    public interface IShipEventGenerator
    {
        IShipEvent GenerateEvent();

        event Action<object, EventArgs>
            OnEventGenerated; // object - ������, ������� ���������� �������; TaskEventArgs - ������ ���� ���������� ������������ �����
    }
}