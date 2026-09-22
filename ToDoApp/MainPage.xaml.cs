using Microsoft.Maui.Layouts;
using Task = ToDoApp.Classes.Task;

namespace ToDoApp
{
    public partial class MainPage : ContentPage
    {
        List<Task> tasks = new List<Task>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void RenderTasksList()
        {
            taskListLayout.Children.Clear();

            if (tasks.Count > 0)
            {
                foreach (Task task in tasks)
                {
                    FlexLayout div = new FlexLayout
                    {
                        Direction = FlexDirection.Row,
                        JustifyContent = FlexJustify.SpaceBetween,
                    };


                    Label label = new Label
                    {
                        Text = task.Text,
                        FontSize = 20,
                    };
                    div.Children.Add(label);


                    Button button = new Button
                    {
                        Text = "Completed",
                    };
                    div.Children.Add(button);

                    Button deleteButton = new Button
                    {
                        Text = "Delete",
                        CommandParameter = task.Id
                    };
                    deleteButton.Clicked += DeketeTaskButton_Clicked;
                    div.Children.Add(deleteButton);


                    taskListLayout.Children.Add(div);
                }
            }
        }

        private void AddTaskButton_Clicked(object sender, EventArgs e)
        {
            if(taskEntry.Text != null)
            {
                Task newTask = new Task(tasks.Count + 1, taskEntry.Text);

                tasks.Add(newTask);

                taskEntry.Text = "";
            }

            RenderTasksList();
        }

        private void DeketeTaskButton_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int taskId = (int)btn.CommandParameter;

            for(int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Id == taskId)
                {
                    tasks.RemoveAt(i);
                }
            }

            RenderTasksList();
        }
    }
}
