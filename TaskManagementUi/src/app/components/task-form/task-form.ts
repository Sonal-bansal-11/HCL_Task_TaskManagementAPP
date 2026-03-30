import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // <-- Two-way binding needed for (ngModel)
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { TaskService } from '../../services/task';
import { TaskItem } from '../../models/task';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule], // FormsModule for ngModel, RouterModule for navigation
  templateUrl: './task-form.html',
  styleUrl: './task-form.css'
})
export class TaskFormComponent implements OnInit {
  // This is the model for our form, it will hold the data for the task being created or edited
  task: TaskItem = { title: '', description: '', isCompleted: false };
  isEditMode = false;

  constructor(
    private taskService: TaskService,
    private router: Router, // To navigate after form submission
    private route: ActivatedRoute // To read the URL parameters for edit mode
  ) {}

  ngOnInit(): void {
    // Check if there's an 'id' parameter in the URL, if yes then we are in edit mode and we need to fetch the existing task data to populate the form
    const id = this.route.snapshot.paramMap.get('id');
    
    if (id) {
      this.isEditMode = true;
      // if we are in edit mode, fetch the existing task data using the ID and populate the form
      this.taskService.getTask(Number(id)).subscribe({
        next: (data) => this.task = data,
        error: (err) => console.error('Error fetching task:', err)
      });
    }
  }

  // When user click save button, this function will be called, it will check if we are in edit mode or create mode and call the appropriate service method to save the task data to the backend
  onSubmit(): void {
    if (this.isEditMode && this.task.id) {
      // UPDATE (PUT Request)
      this.taskService.updateTask(this.task.id, this.task).subscribe({
        next: () => this.router.navigate(['/']), // after successful update, navigate back to the task list page
        error: (err) => console.error('Error updating task:', err)
      });
    } else {
      // CREATE (POST Request)
      this.taskService.createTask(this.task).subscribe({
        next: () => this.router.navigate(['/']),
        error: (err) => console.error('Error creating task:', err)
      });
    }
  }
}