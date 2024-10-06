using System;
using System.Collections.Generic;

// Знімок
public class Memento
{
    public string State { get; }

    public Memento(string state)
    {
        State = state;
    }
}

// Історія знімків
public class Caretaker
{
    private readonly List<Memento> _mementos = new List<Memento>();

    public void AddMemento(Memento memento)
    {
        _mementos.Add(memento);
    }

    public Memento GetMemento(int index)
    {
        return _mementos[index];
    }
}

// Клас, для якого створюються знімки
public class Originator
{
    public string State { get; set; }

    public Memento SaveStateToMemento()
    {
        return new Memento(State);
    }

    public void GetStateFromMemento(Memento memento)
    {
        State = memento.State;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Originator originator = new Originator();
        Caretaker caretaker = new Caretaker();

        originator.State = "Стан 1";
        caretaker.AddMemento(originator.SaveStateToMemento());

        originator.State = "Стан 2";
        caretaker.AddMemento(originator.SaveStateToMemento());

        originator.State = "Стан 3";

        Console.WriteLine("Початковий стан: " + originator.State);

        originator.GetStateFromMemento(caretaker.GetMemento(1));
        Console.WriteLine("Відновлений стан: " + originator.State);
    }
}
