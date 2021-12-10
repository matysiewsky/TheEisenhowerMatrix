namespace TheEisenhowerMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            // Whole code responsible for program running moved to class RunFlow:

            // RunFlow.GetDataBeforeRun() is responsible for the stage before program initialization
            // - generating new Matrix or importing saved one.

            ToDoMatrix currentUserToDoMatrix = RunFlow.GetDataBeforeRun();


            // RunFlow.ProgramRunning() is responsible for main program flow - from the beginning to the end.

            RunFlow.ProgramRunning(currentUserToDoMatrix);
        }
    }
    public enum ProgramMode
    {

        // Enum ProgramMode defines 3 modes in which program works. NotSetYet value is default mode before Matrix initialization.
        // The NewCSV and ExistingCSV - for new and returning users.

        NotSetYet,
        NewCSV,
        ExistingCSV
    }
}