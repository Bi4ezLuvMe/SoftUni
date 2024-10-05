namespace _10._Chronometer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chronometer chronometer = new Chronometer();
            string command = Console.ReadLine();
            while (command is not "exit")
            {
                if(command is "start")
                {
                    Task.Run(() => chronometer.Start());
                }
                else if(command is "stop")
                {
                    chronometer.End();
                }else if(command is "lap")
                {
                    chronometer.Lap();
                }else if(command is "laps")
                {
                    List<string> laps = chronometer.Laps;

                    if(laps.Count is 0)
                    {
                        Console.WriteLine("There is no laps!");
                    }
                    else{
                        Console.WriteLine("Laps:");
                        for (int i = 0; i < laps.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}.{laps[i]}");
                        }
                    }
                }else if(command is "reset")
                {
                    chronometer.Reset();
                }else if (command is "time")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
                command = Console.ReadLine();
            }
            chronometer.End();
        }
    }
}
