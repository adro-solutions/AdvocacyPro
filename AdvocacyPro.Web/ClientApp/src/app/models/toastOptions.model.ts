import { ToastOptions } from '../vendor';

export class ToastMessageOptions {
    type: ToastType;
    title: string;
    body: string;

    constructor(title: string, body: string, type: ToastType) {
        this.title = title;
        this.body = body;
        this.type = type;
    }
}

export enum ToastType {
    Info = 1,
    Warning = 2,
    Error = 3,
    Success = 4
}

export class CustomToastOption extends ToastOptions {
    animate = 'flyRight'; // you can override any options available
    newestOnTop = false;
    showCloseButton = true;
}
