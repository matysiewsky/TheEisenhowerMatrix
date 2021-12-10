using System.Collections.Generic;

namespace TheEisenhowerMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDoMatrix currentUserToDoMatrix = RunFlow.GetDataBeforeRun();

            RunFlow.ProgramRunning(currentUserToDoMatrix);
        }
    }
    public enum ProgramMode
    {
        NotSetYet,
        NewCSV,
        ExistingCSV
    }
}