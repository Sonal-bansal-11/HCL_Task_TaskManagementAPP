

import { Routes } from '@angular/router';
import { TaskListComponent } from './components/task-list/task-list';
import { TaskFormComponent } from './components/task-form/task-form';

export const routes: Routes = [
  { path: '', component: TaskListComponent }, // default page (home page) where list shows
  { path: 'add-task', component: TaskFormComponent }, // /add-task form shows for creating new task
  { path: 'edit-task/:id', component: TaskFormComponent } // /edit-task/5 form shows for editing existing task
];