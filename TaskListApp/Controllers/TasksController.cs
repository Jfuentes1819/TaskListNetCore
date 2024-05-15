using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;

 [ApiController]
[Route("api/Tasks")]
public class TasksController : ControllerBase{

List<Taskitem> taskitems;

public TasksController(){
    taskitems = new List<Taskitem>();
    taskitems.Add(new Taskitem{Name = "Tarea 1", Description = " es la tarea 1"});
    taskitems.Add(new Taskitem{Name = "Tarea 2", Description = " es la tarea 2"});
    taskitems.Add(new Taskitem{Name = "Tarea 3", Description = " es la tarea 3"});
    taskitems.Add(new Taskitem{Name = "Tarea 4", Description = " es la tarea 4"});
    taskitems.Add(new Taskitem{Name = "Tarea 5", Description = " es la tarea 5"});
}

[HttpGet(Name ="GetAllTasks")]  
public ActionResult<List<Taskitem>> GetAllTasks()     { 

return taskitems;

}
 [HttpPost(Name = "AddTask")]
    public ActionResult<Taskitem> AddTask(Taskitem task)
    {
        taskitems.Add(task);
        return CreatedAtAction(nameof(GetAllTasks), task);
    }

    [HttpDelete("{id}", Name = "DeleteTask")]
    public IActionResult DeleteTask(int id)
    {
        var taskToRemove = taskitems.FirstOrDefault(t => t.Id == id);
        if (taskToRemove == null)
        {
            return NotFound();
        }

        taskitems.Remove(taskToRemove);
        return NoContent();
    }

    [HttpPut("{id}", Name = "UpdateTask")]
    public IActionResult UpdateTask(int id, Taskitem updatedTask)
    {
        var existingTask = taskitems.FirstOrDefault(t => t.Id == id);
        if (existingTask == null)
        {
            return NotFound();
        }

        existingTask.Name = updatedTask.Name;
        existingTask.Description = updatedTask.Description;

        return NoContent();
    }
}



