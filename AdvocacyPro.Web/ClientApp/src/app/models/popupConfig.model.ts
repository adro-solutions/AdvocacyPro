export class PopupConfig {
    headerText: string;
    bodyText: string;
    cancelText: string;
    okText: string;
    showCancel: boolean;
    inputValue: string;
    showInput: boolean;

    constructor(headerText: string, bodyText: string) {
        this.headerText = headerText;
        this.bodyText = bodyText;
        this.cancelText = 'Cancel';
        this.okText = 'Ok';
        this.showCancel = false;
        this.inputValue = '';
        this.showInput = false;
    }
}

export class PopupResponse {
    response: boolean;
    input: string;

    constructor(response: boolean, input: string) {
        this.response = response;
        this.input = input;
    }
}
