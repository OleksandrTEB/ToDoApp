namespace ToDoApp.Classes
{
    class Task
    {
        public int Id;
        public string Text;
        public bool Completed;

        public Task(int id, string text)
        {
            Id = id;
            Text = text;
            Completed = false;
        }
    }
}
