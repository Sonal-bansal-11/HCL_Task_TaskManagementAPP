
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaskItem } from '../models/task';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private apiUrl = 'http://localhost:5048/api/tasks'; 

  // HttpClient injected to make API calls
  constructor(private http: HttpClient) { }

  // 1.(GET)
  getTasks(): Observable<TaskItem[]> {
    return this.http.get<TaskItem[]>(this.apiUrl);
  }

  // 2.(GET by ID)
  getTask(id: number): Observable<TaskItem> {
    return this.http.get<TaskItem>(`${this.apiUrl}/${id}`);
  }

  // 3.(POST)
  createTask(task: TaskItem): Observable<TaskItem> {
    return this.http.post<TaskItem>(this.apiUrl, task);
  }

  // 4.(PUT)
  updateTask(id: number, task: TaskItem): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, task);
  }

  // 5.(DELETE)
  deleteTask(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}