export interface TaskItem {
    id?: number; // '?' means it is optional (because during creation, the id is not yet assigned)
    title: string;
    description: string;
    isCompleted: boolean;
}