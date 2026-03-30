import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TaskService } from '../../services/task';
import { TaskItem } from '../../models/task';

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [CommonModule, RouterModule], 
  templateUrl: './task-list.html',
  styleUrl: './task-list.css'
})
export class TaskListComponent implements OnInit {
  // This array will hold the list of tasks fetched from the API
  tasks: TaskItem[] = [];

  // Service injected to make API calls
  constructor(private taskService: TaskService) {}

  // this function will run when the component initializes, it will call loadTasks to fetch the tasks from API
  ngOnInit(): void {
    this.loadTasks();
  }

  // Function to load tasks from the API and store them in the tasks array
  loadTasks(): void {
    this.taskService.getTasks().subscribe({
      next: (data) => {
        this.tasks = data; // Put the fetched tasks into the tasks array to be displayed in the template
      },
      error: (err) => {
        console.error('Error fetching tasks:', err);
      }
    });
  }

  // Function to delete a task by its ID, it will call the deleteTask method of the service and then reload the tasks list after deletion
  deleteTask(id: number | undefined): void {
    if (!id) return;
    
    // Get user confirmation before deleting the task
    if (confirm('Are you sure you want to delete this task?')) {
      this.taskService.deleteTask(id).subscribe({
        next: () => {
          this.loadTasks(); // Reload the tasks list after successful deletion to reflect the changes in the UI
        },
        error: (err) => {
          console.error('Error deleting task:', err);
        }
      });
    }
  }
}
