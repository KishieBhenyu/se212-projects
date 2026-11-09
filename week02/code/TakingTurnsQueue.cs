
/// <summary>
/// A circular queue that gives each person their assigned number of turns.
/// People with zero or negative turns remain in the queue forever.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // Zero or negative turns means infinite turns.
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        else
        {
            person.Turns--;

            // Return the person to the queue if they have turns remaining.
            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
