using System;
using System.Collections.Generic;

public interface ISport
{
    string SportName { get; set; }
    void Play();
    void Stop();
}

public abstract class TeamSport : ISport
{
    public string SportName { get; set; }
    public int NumberOfPlayers { get; set; }
    public bool IsIndoor { get; set; }

    public abstract void Play();
    public abstract void Stop();

    public void PrintInfo()
    {
        Console.WriteLine($"Спорт : {SportName}");
        Console.WriteLine($"Количество игроков : {NumberOfPlayers}");
        Console.WriteLine($"Закрытый стадион : {(IsIndoor ? "Yes" : "No")}");
    }
}

public class Football : TeamSport
{
    public string StadiumName { get; set; }
    public int NumberOfGoals { get; set; }

    public override void Play()
    {
        Console.WriteLine($"Игра проходит на стадионе {StadiumName}");
    }

    public override void Stop()
    {
        Console.WriteLine("Окончание игры");
    }

    public void ScoreGoal()
    {
        NumberOfGoals++;
        Console.WriteLine("Забит гол!");
    }

    public void ChangeStadium(string newStadium)
    {
        StadiumName = newStadium;
        Console.WriteLine($"Стадион сменен на  {newStadium}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<ISport> sports = new List<ISport>();

        Football football = new Football()
        {
            SportName = "Футбол",
            NumberOfPlayers = 11,
            IsIndoor = false,
            StadiumName = "Трэффорд"
        };
        sports.Add(football);

        foreach (ISport sport in sports)
        {
            sport.Play();
            if (sport is Football)
            {
                Football f = (Football)sport;
                f.ScoreGoal();
            }
            sport.Stop();
        }


        football.PrintInfo();

        Console.ReadLine();
    }
}
