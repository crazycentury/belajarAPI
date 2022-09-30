using System;
namespace WebApi.Models
{
    public class Users
    {
        public int pk_id { get; set; }
        public string name { get; set; }

        public List<Task> tasks { get; set; }
    }

    public class Task
    {
        public int pk_tasks_id { get; set; }
        public string task_detail { get; set; }
        public int fk_user_id { get; set; }
    }

    
}

